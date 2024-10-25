using System;
using System.Collections.Generic;
using UnityEngine;

namespace FHFramework
{
    [Serializable]
    public class PanelGroup
    {
        [SerializeField]
        private string m_GroupID;
        private Transform m_Root;
        private PanelBase m_OpenPanel;
        private LinkedList<PanelBase> m_ReverseStack;

        public string GroupID
        {
            get
            {
                return m_GroupID;
            }
        }

        public void Init(Transform root)
        {
            m_OpenPanel = null;
            m_ReverseStack = new();
            m_Root = root;
        }

        /// <summary>
        /// ���UIForm��UIGroup
        /// </summary>
        /// <param name="formBase"></param>
        public void AddUIForm(PanelBase panelBase)
        {
            
        }

        /// <summary>
        /// �رյ�ǰ���м�������
        /// �رպ󲢲�����������
        /// �����ɶ�����Զ�����
        /// </summary>
        /// <param name="formBase"></param>
        /// <param name="isRelease"></param>
        public void CloseUIForm(PanelBase formBase)
        {
            
        }
    }
}