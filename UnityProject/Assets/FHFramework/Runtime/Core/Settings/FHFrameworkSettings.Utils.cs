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
                        LogHelper.Log(LogLevel.Error, $"Could not found FHFrameworkSettings asset, so auto create:{SettingsPath}");
                    }
                }

                return m_FHFrameworkSettings;
            }
        }
    }
}