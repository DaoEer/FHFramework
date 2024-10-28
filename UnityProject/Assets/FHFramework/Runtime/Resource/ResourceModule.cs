using YooAsset;

namespace FHFramework
{
    /// <summary>
    /// 资源模块
    /// </summary>
    public partial class ResourceModule : FHFrameworkModule
    {
        public string defaultPackageName = "DefaultPackage";
        public EPlayMode playMode = EPlayMode.EditorSimulateMode;

        public string PackageVersion { get; set; }
        public ResourceDownloaderOperation Downloader { get; set; }

        protected override void Awake()
        {
            YooAssets.Initialize();
        }
    }
}
