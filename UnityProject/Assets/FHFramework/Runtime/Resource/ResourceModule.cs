using YooAsset;

namespace FHFramework
{
    /// <summary>
    /// ��Դģ��
    /// </summary>
    public partial class ResourceModule : FHFrameworkModule
    {
        private void Start()
        {
            YooAssets.Initialize();
        }
    }
}
