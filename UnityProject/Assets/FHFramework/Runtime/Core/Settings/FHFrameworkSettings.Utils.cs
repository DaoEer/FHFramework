using UnityEngine;

namespace FHFramework
{
    public partial class FHFrameworkSettings
    {
        public const string SettingsPath = "Assets/Resources/FHFrameworkSettings.asset";

        private static FHFrameworkSettings m_FHFrameworkSettings;

        public static FHFrameworkSettings Instance
        {
            get
            {
                if (!m_FHFrameworkSettings)
                {
                    m_FHFrameworkSettings = GetSingletonAssetsByResources();
                }

                return m_FHFrameworkSettings;
            }
        }

        private static FHFrameworkSettings GetSingletonAssetsByResources()
        {
            FHFrameworkSettings settings = Resources.Load<FHFrameworkSettings>(SettingsPath);
            if (!settings)
            {
                LogHelper.Log(LogLevel.Error, $"Could not found FHFrameworkSettings asset, so auto create:{SettingsPath}");
            }

            return settings;
        }
    }
}