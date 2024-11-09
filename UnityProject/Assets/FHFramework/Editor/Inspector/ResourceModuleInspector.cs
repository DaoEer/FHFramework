using System;
using System.Linq;
using FHFramework;
using UnityEditor;
using YooAsset.Editor;

namespace Tengine
{
    [CustomEditor(typeof(ResourceModule))]
    public class ResourceModuleInspector : Editor
    {
        private readonly string[] _resourceModeNames = new string[]
        {
            "EditorSimulateMode (编辑器下的模拟模式)",
            "OfflinePlayMode (单机模式)",
            "HostPlayMode (联机运行模式)",
            "WebPlayMode (WebGL运行模式)"
        };

        private SerializedProperty _playMode;
        private SerializedProperty _packageName;

        private string[] _packageNames;
        private int _packageNameIndex;

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            serializedObject.Update();
            ResourceModule module = (ResourceModule)target;
            _packageNames = GetBuildPackageNames();
            _packageNameIndex = Array.IndexOf(_packageNames, _packageName);
            _packageNameIndex = _packageNameIndex < 0 ? 0 : _packageNameIndex;
            EditorGUILayout.Popup("Package Name", _packageNameIndex, _packageNames);
            serializedObject.ApplyModifiedProperties();
        }

        private void OnEnable()
        {
            _playMode = serializedObject.FindProperty("_playMode");
            _packageName = serializedObject.FindProperty("_playMode");
            serializedObject.ApplyModifiedProperties();
        }

        private string[] GetBuildPackageNames()
        {
            return AssetBundleCollectorSettingData.Setting.Packages.Select(package => package.PackageName).ToArray();
        }
    }
}