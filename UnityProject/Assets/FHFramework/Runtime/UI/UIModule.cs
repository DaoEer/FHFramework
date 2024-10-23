using Cysharp.Threading.Tasks;
using System;
using UnityEngine;

namespace FHFramework
{
    public partial class UIModule : FHFrameworkModule
    {
        public void OpenPanel<T>() where T : PanelBase
        {
            OpenPanel(typeof(T));
        }

        public void OpenPanel(Type panelType)
        {
            IPanel panel = CreatePanel(panelType);
            GameObject panelInstance = InstantiatePanel();
            panel.Init(panelInstance);
        }

        private IPanel CreatePanel(Type panelType)
        {
            PanelBase panel = Activator.CreateInstance(panelType) as PanelBase;
            return panel;
        }

        private async UniTask<GameObject> InstantiatePanel(string location)
        {
            return await GameEntry.Resource.LoadAssetAsync<GameObject>(location);
        }
    }
}