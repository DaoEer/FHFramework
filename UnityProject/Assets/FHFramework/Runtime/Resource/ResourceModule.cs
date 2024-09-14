using YooAsset;

namespace FHFramework
{
    /// <summary>
    /// ×ÊÔ´Ä£¿é
    /// </summary>
    public partial class ResourceModule : FHFrameworkModule
    {
        private void Start()
        {
            YooAssets.Initialize();
        }
    }
}
