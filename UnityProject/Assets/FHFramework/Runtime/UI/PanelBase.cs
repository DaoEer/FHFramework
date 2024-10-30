namespace FHFramework
{
    public class PanelBase : PoolObjectBase, IPanel
    {
        private PanelLogicBase _panelLogic;

        protected override void OnSpawn()
        {
            
        }

        public void Init()
        {
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