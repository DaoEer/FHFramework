using System;
using System.Collections.Generic;
using UnityEngine;

namespace FHFramework
{
    public partial class UIModule : FHFrameworkModule
    {
        [SerializeField] private Transform root;
        [SerializeField] private List<PanelGroup> groups;

        private Dictionary<string, PanelGroup> _groupDictionary;

        protected override void Awake()
        {
            base.Awake();

            _groupDictionary = new Dictionary<string, PanelGroup>();
            root.gameObject.layer = LayerMask.NameToLayer("UI");
            foreach (PanelGroup panelGroup in groups)
            {
                Transform groupRoot = new GameObject(panelGroup.GroupID, typeof(Canvas)).transform;
                groupRoot.SetParent(root);
                groupRoot.GetComponent<RectTransform>().SetStretchMode();
                panelGroup.Init(groupRoot);
                _groupDictionary.Add(panelGroup.GroupID, panelGroup);
            }
        }

        public void OpenPanel<T>() where T : PanelBase, new()
        {
            Type panelType = typeof(T);
            PanelAttribute attribute = Attribute.GetCustomAttribute(panelType, typeof(PanelAttribute)) as PanelAttribute;
            if (attribute == null)
            {
                LogHelper.LogError($"无效的面板：{panelType}");
                return;
            }

            IObjectPool<PanelPoolObject<T>> pool = GameEntry.Pool.GetObjectPool<PanelPoolObject<T>>();
            if (!pool.TrySpawn(out PanelPoolObject<T> panelPoolObject))
            {
                T panel = new T();
                panelPoolObject = new PanelPoolObject<T>();
                panelPoolObject.Initialize(panel);
                pool.Register(panelPoolObject, true);
            }

            InitPanel(panelPoolObject.Panel, attribute.Path, attribute.Logic);
        }

        private async void InitPanel(PanelBase panel, string assetPath, Type logicType)
        {
            GameObject panelInstance = await GameEntry.Resource.LoadAssetAsync<GameObject>(assetPath);
            if (panelInstance == null)
            {
                LogHelper.LogError($"UI资源地址无效：{assetPath}");
            }

            PanelLogicBase panelLogic = Activator.CreateInstance(logicType) as PanelLogicBase;
            panel.Init(panelInstance, panelLogic);
            panel.Open();
        }
    }
}