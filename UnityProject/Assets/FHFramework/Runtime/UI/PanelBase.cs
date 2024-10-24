using System;
using UnityEngine;

namespace FHFramework
{
    public class PanelBase : IPanel
    {
        private GameObject m_PanelInstance;
        private PanelLogicBase m_PanelLogic;

        public void Init(GameObject panelInstance, Type logicType)
        {
            m_PanelInstance = panelInstance;
            m_PanelLogic = Activator.CreateInstance(logicType) as PanelLogicBase;
            m_PanelLogic.OnInit();
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