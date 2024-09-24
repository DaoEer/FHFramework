using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine.UIElements;

namespace FHFramework
{
    public class FHFrameworkSettingsProvider : SettingsProvider
    {
        private const string HeaderName = "FHFramework/FHFrameworkSettings";
        private SerializedObject m_Settings;

        public FHFrameworkSettingsProvider(string path, SettingsScope scopes, IEnumerable<string> keywords = null) : base(path, scopes, keywords) { }

        public override void OnActivate(string searchContext, VisualElement rootElement)
        {
            base.OnActivate(searchContext, rootElement);
            if (!File.Exists(FHFrameworkSettings.SettingsPath))
            {
                LogHelper.Log(LogLevel.Error, $"Open FHFramework Settings error, Please Create FHFrameworkSettings.assets File in Path: {FHFrameworkSettings.SettingsPath}");
            }
            
        }

        public override void OnGUI(string searchContext)
        {
            base.OnGUI(searchContext);
            EditorGUILayout.PropertyField(m_Settings.FindProperty("m_FHFrameworkSettings"));
        }
    }
}