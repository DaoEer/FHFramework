using System;
using System.Collections.Generic;
using UnityEngine;

namespace FHFramework
{
    public partial class UIModule : FHFrameworkModule
    {
        [SerializeField]
        private Transform root;
        [SerializeField]
        private List<PanelGroup> groups;
        
        private IObjectPool<PanelPoolObject> _pool;
        private Dictionary<string, PanelGroup> _groupDictionary;

        protected override void Awake()
        {
            base.Awake();

            _groupDictionary = new Dictionary<string, PanelGroup>();
            _pool = GameEntry.Pool.GetObjectPool<PanelPoolObject>();
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

        public void OpenPanelSync<T>() where T : PanelBase
        {
            OpenPanelSync(typeof(T));
        }

        public void OpenPanelSync(Type panelType)
        {
            PanelAttribute attribute = Attribute.GetCustomAttribute(panelType, typeof(PanelAttribute)) as PanelAttribute;
            if (attribute == null)
            {
                Debug.LogError(panelType + " is not a Panel");
                return;
            }

            if (!_pool.TrySpawn(out PanelPoolObject panelObject))
            {
                CreatePanel(panelType);
            }
        }

        public void ClosePanel<T>()
        {
            ClosePanel(typeof(T));
        }

        public void ClosePanel(Type panelType)
        {

        }

        public IPanel CreatePanel(Type panelType)
        {
            return Activator.CreateInstance(panelType) as IPanel;
        }

        public GameObject InstantiatePanel(string path)
        {
            GameObject panelInstance = GameEntry.Resource.LoadAssetSync<GameObject>(path);
            if (panelInstance == null)
            {
                Debug.LogError("UI资源地址无效");
            }

            return panelInstance;
        }
    }
}