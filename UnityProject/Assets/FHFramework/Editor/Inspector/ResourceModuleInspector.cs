using System;
using System.Linq;
using FHFramework;
using UnityEditor;
using YooAsset;
using YooAsset.Editor;

namespace Tengine
{
    [CustomEditor(typeof(ResourceModule))]
    public class ResourceModuleInspector : Editor
    {
        private SerializedProperty _packageName;

        private EPlayMode _playMode = EPlayMode.EditorSimulateMode;
        private string[] _packageNames;
        private int _packageNameIndex;

        private void OnEnable()
        {
            _playMode = (EPlayMode)serializedObject.FindProperty("_playMode").enumValueIndex;
            _packageName = serializedObject.FindProperty("_packageName");
            serializedObject.ApplyModifiedProperties();
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            serializedObject.Update();
            ResourceModule module = (ResourceModule)target;

            _playMode = module == null ? _playMode : module.PlayMode;
            _playMode = (EPlayMode)EditorGUILayout.EnumPopup("Play Mode", _playMode);

            _packageNames = GetBuildPackageNames();
            _packageNameIndex = Array.IndexOf(_packageNames, _packageName);
            _packageNameIndex = _packageNameIndex < 0 ? 0 : _packageNameIndex;
            EditorGUILayout.Popup("Package Name", _packageNameIndex, _packageNames);

            serializedObject.ApplyModifiedProperties();
        }

        private string[] GetBuildPackageNames()
        {
            return AssetBundleCollectorSettingData.Setting.Packages.Select(package => package.PackageName).ToArray();
        }
    }
}