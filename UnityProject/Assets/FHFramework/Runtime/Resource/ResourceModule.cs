using YooAsset;

namespace FHFramework
{
    /// <summary>
    /// ��Դģ��
    /// </summary>
    public partial class ResourceModule : FHFrameworkModule
    {
        private const string m_DefaultPackageName = "DefaultPackage";

        private void Start()
        {
            YooAssets.Initialize();
        }

        public void InitPackage()
        {
#if UNITY_EDITOR

#else

#endif
        }
    }
}
