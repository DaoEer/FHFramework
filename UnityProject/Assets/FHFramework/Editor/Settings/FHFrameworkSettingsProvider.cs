using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine.UIElements;

namespace FHFramework
{
    public class FHFrameworkSettingsProvider : SettingsProvider
    {
        private const string SettingsPath = "Assets/Resources/" + FHFrameworkSettings.SettingsPath + ".asset";
        private const string HeaderName = "FHFramework/FHFrameworkSettings";
        private const string PropertyName = "m_GlobalSettings";
        private SerializedObject m_Settings;

        public FHFrameworkSettingsProvider(string path, SettingsScope scopes, IEnumerable<string> keywords = null) : base(path, scopes, keywords) { }

        public override void OnActivate(string searchContext, VisualElement rootElement)
        {
            base.OnActivate(searchContext, rootElement);
            m_Settings = new SerializedObject(FHFrameworkSettings.Instance);
        }

        public override void OnGUI(string searchContext)
        {
            base.OnGUI(searchContext);
            using EditorGUI.ChangeCheckScope changeCheckScope = new();
            EditorGUILayout.PropertyField(m_Settings.FindProperty(PropertyName));

            if (!changeCheckScope.changed) return;
            m_Settings.ApplyModifiedPropertiesWithoutUndo();
        }

        [SettingsProvider]
        private static SettingsProvider CreateMySettingsProvider()
        {
            if (!File.Exists(SettingsPath))
            {
                LogHelper.LogError($"Open FHFramework Settings error, Please Create FHFrameworkSettings.assets File in Path: {SettingsPath}");
                return null;
            }

            FHFrameworkSettingsProvider provider = new(HeaderName, SettingsScope.Project);
            provider.keywords = GetSearchKeywordsFromGUIContentProperties<FHFrameworkSettingsProvider>();
            return provider;
        }
    }
}