using FHFramework;
using YooAsset.Editor;

namespace Tengine
{
    using System;
    using System.Linq;
    using UnityEditor;
    using UnityEngine;

    [CustomEditor(typeof(ResourceModule))]
    public class ResourceModuleInspector : Editor
    {
        private SerializedProperty _packageName;
        private SerializedProperty _playMode;
        private string[] _packageNames;
        private int _packageNameIndex;

        private void OnEnable()
        {
            // 初始化序列化属性
            _packageName = serializedObject.FindProperty("_packageName");
            _playMode = serializedObject.FindProperty("_playMode");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            // 选择 Play Mode
            EditorGUILayout.PropertyField(_playMode, new GUIContent("Play Mode"));

            // 获取 Package Names，并更新 Popup 选项
            _packageNames = GetBuildPackageNames();
            _packageNameIndex = Array.IndexOf(_packageNames, _packageName.stringValue);
            _packageNameIndex = Mathf.Max(0, _packageNameIndex);

            // 绘制 Package Name 的 Popup
            int selectedPackageIndex = EditorGUILayout.Popup("Package Name", _packageNameIndex, _packageNames);
            if (selectedPackageIndex != _packageNameIndex)
            {
                _packageNameIndex = selectedPackageIndex;
                _packageName.stringValue = _packageNames[_packageNameIndex]; // 更新序列化属性
            }

            serializedObject.ApplyModifiedProperties();
        }

        private string[] GetBuildPackageNames()
        {
            // 从 AssetBundleCollectorSettingData 中获取包名称数组
            return AssetBundleCollectorSettingData.Setting.Packages.Select(package => package.PackageName).ToArray();
        }
    }
}