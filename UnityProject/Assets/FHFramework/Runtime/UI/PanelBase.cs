using System;
using UnityEngine;

namespace FHFramework
{
    public class PanelBase : IPanel
    {
        private GameObject _panelInstance;
        private PanelLogicBase _panelLogic;

        public GameObject Root
        {
            get
            {
                return _panelInstance;
            }
        }

        public void Init(GameObject panelInstance, Type logicType)
        {
            _panelInstance = panelInstance;
            _panelLogic = Activator.CreateInstance(logicType) as PanelLogicBase;
            _panelLogic!.OnInit(this);
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

        public void Destroy()
        {
            
        }
    }
}