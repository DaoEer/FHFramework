using System;
using UnityEngine;

namespace FHFramework
{
    public partial class UIModule : FHFrameworkModule
    {
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

        private IPanel CreatePanel(Type panelType)
        {
            PanelBase panel = Activator.CreateInstance(panelType) as PanelBase;
            return panel;
        }
    }
}