using System;
using System.Collections.Generic;
using UnityEngine;

namespace FHFramework
{
    [Serializable]
    public class PanelGroup
    {
        [SerializeField]
        private string groupID;
        private Transform _root;
        private PanelBase _openPanel;
        private LinkedList<PanelBase> _reverseStack;

        public string GroupID
        {
            get
            {
                return groupID;
            }
        }

        public void Init(Transform root)
        {
            _openPanel = null;
            _reverseStack = new LinkedList<PanelBase>();
            _root = root;
        }
        
        public void AddUIForm(PanelBase panelBase)
        {
            
        }
        
        public void CloseUIForm(PanelBase formBase)
        {
            
        }
    }
}