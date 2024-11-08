using Cysharp.Threading.Tasks;
using UnityEditor;
using YooAsset;

namespace FHFramework
{
    /// <summary>
    /// 资源模块
    /// </summary>
    public partial class ResourceModule : FHFrameworkModule
    {
        public EPlayMode playMode = EPlayMode.EditorSimulateMode;

        public string PackageVersion { get; set; }
        public ResourceDownloaderOperation Downloader { get; set; }

        protected override void Awake()
        {
            YooAssets.Initialize();
        }

        public async UniTask<InitializationOperation> InitPackage(string packageName)
        {
            ResourcePackage package = YooAssets.TryGetPackage(packageName);
            package ??= YooAssets.CreatePackage(packageName);

            InitializationOperation initializationOperation = null;
            switch (GameEntry.Resource.playMode)
            {
                case EPlayMode.EditorSimulateMode:
                    {
                        SimulateBuildResult simulateBuildResult = EditorSimulateModeHelper.SimulateBuild(EDefaultBuildPipeline.BuiltinBuildPipeline, packageName);
                        EditorSimulateModeParameters createParameters = new EditorSimulateModeParameters();
                        createParameters.EditorFileSystemParameters = FileSystemParameters.CreateDefaultEditorFileSystemParameters(simulateBuildResult);
                        initializationOperation = package.InitializeAsync(createParameters);
                        break;
                    }
                // 单机运行模式
                case EPlayMode.OfflinePlayMode:
                    {
                        OfflinePlayModeParameters createParameters = new OfflinePlayModeParameters();
                        createParameters.BuildinFileSystemParameters = FileSystemParameters.CreateDefaultBuildinFileSystemParameters();
                        initializationOperation = package.InitializeAsync(createParameters);
                        break;
                    }
                // 联机运行模式
                case EPlayMode.HostPlayMode:
                    {
                        string defaultHostServer = GetHostServerURL();
                        string fallbackHostServer = GetHostServerURL();
                        IRemoteServices remoteServices = new RemoteServices(defaultHostServer, fallbackHostServer);
                        HostPlayModeParameters createParameters = new HostPlayModeParameters();
                        createParameters.BuildinFileSystemParameters = FileSystemParameters.CreateDefaultBuildinFileSystemParameters();
                        createParameters.CacheFileSystemParameters = FileSystemParameters.CreateDefaultCacheFileSystemParameters(remoteServices);
                        initializationOperation = package.InitializeAsync(createParameters);
                        break;
                    }
                // WebGL运行模式
                case EPlayMode.WebPlayMode:
                    {
                        WebPlayModeParameters createParameters = new WebPlayModeParameters();
                        createParameters.WebFileSystemParameters = FileSystemParameters.CreateDefaultWebFileSystemParameters();
                        initializationOperation = package.InitializeAsync(createParameters);
                        break;
                    }
            }

            await initializationOperation;
            return initializationOperation;
        }

        private string GetHostServerURL()
        {
            string hostServerIP = "http://127.0.0.1";
            string appVersion = "v1.0";

#if UNITY_EDITOR
            if (EditorUserBuildSettings.activeBuildTarget == BuildTarget.Android)
                return $"{hostServerIP}/CDN/Android/{appVersion}";
            else if (EditorUserBuildSettings.activeBuildTarget == BuildTarget.iOS)
                return $"{hostServerIP}/CDN/IPhone/{appVersion}";
            else if (EditorUserBuildSettings.activeBuildTarget == BuildTarget.WebGL)
                return $"{hostServerIP}/CDN/WebGL/{appVersion}";
            else
                return $"{hostServerIP}/CDN/PC/{appVersion}";
#else
        if (Application.platform == RuntimePlatform.Android)
            return $"{hostServerIP}/CDN/Android/{appVersion}";
        else if (Application.platform == RuntimePlatform.IPhonePlayer)
            return $"{hostServerIP}/CDN/IPhone/{appVersion}";
        else if (Application.platform == RuntimePlatform.WebGLPlayer)
            return $"{hostServerIP}/CDN/WebGL/{appVersion}";
        else
            return $"{hostServerIP}/CDN/PC/{appVersion}";
#endif
        }

        /// <summary>
        /// 远端资源地址查询服务类
        /// </summary>
        private class RemoteServices : IRemoteServices
        {
            private readonly string _defaultHostServer;
            private readonly string _fallbackHostServer;

            public RemoteServices(string defaultHostServer, string fallbackHostServer)
            {
                _defaultHostServer = defaultHostServer;
                _fallbackHostServer = fallbackHostServer;
            }

            string IRemoteServices.GetRemoteMainURL(string fileName)
            {
                return $"{_defaultHostServer}/{fileName}";
            }

            string IRemoteServices.GetRemoteFallbackURL(string fileName)
            {
                return $"{_fallbackHostServer}/{fileName}";
            }
        }
    }
}
