namespace FHFramework
{
    public abstract class FsmState
    {
        public virtual void OnEnter() { }

        public virtual void OnUpdate() { }

        public virtual void OnLeave() { }
    }
}