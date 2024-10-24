using System;
using UnityEngine;

namespace FHFramework
{
    public interface IPanel
    {
        public void Init(GameObject panelInstance, Type logicType);

        public void Open();

        public void Update();

        public void Close();

        public void Destory();
    }
}