using UnityEngine;

namespace FHFramework
{
    public partial class FHFrameworkSettings
    {
        public const string SettingsPath = "FHFrameworkSettings";

        private static FHFrameworkSettings m_FHFrameworkSettings;

        public static FHFrameworkSettings Instance
        {
            get
            {
                if (!m_FHFrameworkSettings)
                {
                    m_FHFrameworkSettings = Resources.Load<FHFrameworkSettings>(SettingsPath);
                    if (!m_FHFrameworkSettings)
                    {
                        LogHelper.LogError($"Could not found FHFrameworkSettings asset, so auto create:{SettingsPath}");
                    }
                }

                return m_FHFrameworkSettings;
            }
        }

        public static FHFrameworkGlobalSettings GlobalSettings => Instance.m_GlobalSettings;
    }
}