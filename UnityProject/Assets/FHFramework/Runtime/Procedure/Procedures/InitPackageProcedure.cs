using Cysharp.Threading.Tasks;
using UnityEditor;
using YooAsset;

namespace FHFramework
{
    public class InitPackageProcedure : Procedure
    {
        public override void OnEnter()
        {
            LogHelper.Log(LogLevel.Log, "InitPackageProcedure：初始化资源包流程");

            InitPackage().Forget();
        }

        public async UniTask InitPackage()
        {
            ResourcePackage package = YooAssets.TryGetPackage(GameEntry.Resource.DefaultPackageName);
            package ??= YooAssets.CreatePackage(GameEntry.Resource.DefaultPackageName);

            InitializationOperation initializationOperation = null;
            if (GameEntry.Resource.PlayMode == EPlayMode.EditorSimulateMode)
            {
                SimulateBuildResult simulateBuildResult = EditorSimulateModeHelper.SimulateBuild(GameEntry.Resource.DefaultPackageName, GameEntry.Resource.DefaultPackageName);
                EditorSimulateModeParameters createParameters = new();
                createParameters.EditorFileSystemParameters = FileSystemParameters.CreateDefaultEditorFileSystemParameters(simulateBuildResult);
                initializationOperation = package.InitializeAsync(createParameters);
            }

            // 单机运行模式
            if (GameEntry.Resource.PlayMode == EPlayMode.OfflinePlayMode)
            {
                OfflinePlayModeParameters createParameters = new();
                createParameters.BuildinFileSystemParameters = FileSystemParameters.CreateDefaultBuildinFileSystemParameters();
                initializationOperation = package.InitializeAsync(createParameters);
            }

            // 联机运行模式
            if (GameEntry.Resource.PlayMode == EPlayMode.HostPlayMode)
            {
                string defaultHostServer = GetHostServerURL();
                string fallbackHostServer = GetHostServerURL();
                IRemoteServices remoteServices = new RemoteServices(defaultHostServer, fallbackHostServer);
                HostPlayModeParameters createParameters = new();
                createParameters.BuildinFileSystemParameters = FileSystemParameters.CreateDefaultBuildinFileSystemParameters();
                createParameters.CacheFileSystemParameters = FileSystemParameters.CreateDefaultCacheFileSystemParameters(remoteServices);
                initializationOperation = package.InitializeAsync(createParameters);
            }

            // WebGL运行模式
            if (GameEntry.Resource.PlayMode == EPlayMode.WebPlayMode)
            {
                WebPlayModeParameters createParameters = new();
                createParameters.WebFileSystemParameters = FileSystemParameters.CreateDefaultWebFileSystemParameters();
                initializationOperation = package.InitializeAsync(createParameters);
            }

            await initializationOperation;
            if (!initializationOperation.Status.Equals(EOperationStatus.Succeed))
            {
                LogHelper.Log(LogLevel.Error, initializationOperation.Error);
            }
            else
            {
                GameEntry.Procedure.ProcedureFsm.SwitchState<UpdateVersionProcedure>();
            }
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
