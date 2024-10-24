namespace FHFramework
{
    public class UIPoolObject<T> : PoolObjectBase where T : PanelBase
    {
        public new T Object => base.Object as T;

        protected override void OnRelease()
        {
            Object.Destory();
            UnityEngine.Object.Destroy(Object.Root);
        }
    }
}