namespace FHFramework
{
    public class UIPoolObject<T> : PoolObjectBase where T : PanelBase
    {
        public new T Object
        {
            get
            {
                return base.Object as T;
            }
        }

        protected override void OnRelease()
        {
            Object.Destroy();
            UnityEngine.Object.Destroy(Object.Root);
        }
    }
}