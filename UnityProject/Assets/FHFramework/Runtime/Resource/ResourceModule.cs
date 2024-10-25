using Cysharp.Threading.Tasks;
using UnityEditor;
using YooAsset;

namespace FHFramework
{
    /// <summary>
    /// ×ÊÔ´Ä£¿é
    /// </summary>
    public partial class ResourceModule : FHFrameworkModule
    {
        public string DefaultPackageName = "DefaultPackage";
        public EPlayMode PlayMode;

        public string PackageVersion { get; set; }
        public ResourceDownloaderOperation Downloader { get; set; }

        protected override void Awake()
        {
            YooAssets.Initialize();
        }
    }
}
