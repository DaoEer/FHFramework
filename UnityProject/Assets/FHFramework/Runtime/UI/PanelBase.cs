using UnityEngine;

namespace FHFramework
{
    public class PanelBase
    {
        private GameObject _panel;
        private PanelLogicBase _panelLogic;

        public void Init(GameObject panelInstance, PanelLogicBase panelLogic)
        {
            _panel = panelInstance;
            _panelLogic = panelLogic;
            _panelLogic!.OnInit(this);
        }

        public void Open()
        {
            _panelLogic.OnOpen();
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