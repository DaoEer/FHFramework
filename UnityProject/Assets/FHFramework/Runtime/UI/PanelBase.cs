using System;
using UnityEngine;

namespace FHFramework
{
    public class PanelBase : IPanel
    {
        private GameObject m_PanelInstance;
        private PanelLogicBase m_PanelLogic;

        public GameObject Root
        {
            get
            {
                return m_PanelInstance;
            }
        }

        public void Init(GameObject panelInstance, Type logicType)
        {
            m_PanelInstance = panelInstance;
            m_PanelLogic = Activator.CreateInstance(logicType) as PanelLogicBase;
            m_PanelLogic.OnInit(this);
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