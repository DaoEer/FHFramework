using UnityEngine;

namespace FHFramework
{
    /// <summary>
    /// ¿ò¼ÜÄ£¿é»ùÀà
    /// </summary>
    public abstract class FHFrameworkModule : MonoBehaviour
    {
        public virtual int Priority => 0;

        protected virtual void Awake()
        {
            FHFrameworkEntry.RegisterModule(this);
        }

        public virtual void UpdateModule(float elapseSeconds, float realElapseSeconds) { }
    }
}