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
        
        private Dictionary<string, PanelGroup> _groupDictionary;

        protected override void Awake()
        {
            base.Awake();

            _groupDictionary = new Dictionary<string, PanelGroup>();
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
            IPanel panel = CreatePanel(panelType);
            PanelAttribute panelAttribute = Attribute.GetCustomAttribute(panelType, typeof(PanelAttribute)) as PanelAttribute;
            GameObject panelInstance = GameEntry.Resource.LoadAssetSync<GameObject>(panelAttribute!.Path);
            panel.Init(panelInstance, panelAttribute!.Logic);
        }

        public void OpenPanelAsync<T>() where T : PanelBase
        {
            OpenPanelAsync(typeof(T));
        }

        public async void OpenPanelAsync(Type panelType)
        {
            IPanel panel = CreatePanel(panelType);
            PanelAttribute panelAttribute = Attribute.GetCustomAttribute(panelType, typeof(PanelAttribute)) as PanelAttribute;
            GameObject panelInstance = await GameEntry.Resource.LoadAssetAsync<GameObject>(panelAttribute!.Path);
            panel.Init(panelInstance, panelAttribute!.Logic);
        }

        public void ClosePanel<T>()
        {
            ClosePanel(typeof(T));
        }

        public void ClosePanel(Type panelType)
        {

        }

        private IPanel CreatePanel(Type panelType)
        {
            PanelBase panel = Activator.CreateInstance(panelType) as PanelBase;
            return panel;
        }
    }
}