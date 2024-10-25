using System;
using System.Collections.Generic;
using UnityEngine;

namespace FHFramework
{
    public partial class UIModule : FHFrameworkModule
    {
        [SerializeField]
        private Transform m_Root;
        [SerializeField]
        private List<PanelGroup> m_Groups;
        private Dictionary<string, PanelGroup> m_GroupDictionary;

        protected override void Awake()
        {
            base.Awake();

            m_GroupDictionary = new();
            foreach (PanelGroup panelGroup in m_Groups)
            {
                Transform groupRoot = new GameObject(panelGroup.GroupID, typeof(RectTransform)).transform;
                groupRoot.SetParent(m_Root);
                groupRoot.GetComponent<RectTransform>().SetStretchMode();
                panelGroup.Init(groupRoot);
                m_GroupDictionary.Add(panelGroup.GroupID, panelGroup);
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
            GameObject panelInstance = GameEntry.Resource.LoadAssetSync<GameObject>(panelAttribute.Path);
            panel.Init(panelInstance, panelAttribute.Logic);
        }

        public void OpenPanelAsync<T>() where T : PanelBase
        {
            OpenPanelAsync(typeof(T));
        }

        public async void OpenPanelAsync(Type panelType)
        {
            IPanel panel = CreatePanel(panelType);
            PanelAttribute panelAttribute = Attribute.GetCustomAttribute(panelType, typeof(PanelAttribute)) as PanelAttribute;
            GameObject panelInstance = await GameEntry.Resource.LoadAssetAsync<GameObject>(panelAttribute.Path);
            panel.Init(panelInstance, panelAttribute.Logic);
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