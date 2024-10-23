using UnityEngine;

namespace FHFramework
{
    public class PanelBase : IPanel
    {
        private GameObject m_PanelInstance;
        private PanelLogicBase m_PanelLogic;

        public Transform Root
        {
            get
            {
                return m_PanelInstance.transform;
            }
        }

        public void Init(GameObject panelInstance)
        {
            
        }

        public void Open()
        {
            
        }

        public void Update()
        {
            
        }

        public void Close()
        {
            
        }

        public void Destory()
        {
            
        }
    }
}