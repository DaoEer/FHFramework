namespace FHFramework
{
    public class PanelPoolObject<T> : PoolObjectBase where T : PanelBase
    {
        public T Panel { get; private set; }

        public void Initialize(T panel)
        {
            Panel = panel;
            base.Initialize(Panel);
        }
    }
}