using System;

namespace FHFramework
{
    public class PoolObjectBase
    {
        private object m_Object;

        /// <summary>
        /// 获取对象
        /// </summary>
        public virtual object Object
        {
            get
            {
                return m_Object;
            }
        }

        /// <summary>
        /// 获取对象是否正在使用
        /// </summary>
        public bool IsInUse
        {
            get;
            private set;
        }

        /// <summary>
        /// 是否锁定对象不被释放
        /// </summary>
        public bool IsLock
        {
            get;
            set;
        }

        /// <summary>
        /// 对象上次使用的时间
        /// </summary>
        public DateTime LastUseTime
        {
            get;
            set;
        }

        public PoolObjectBase()
        {
            m_Object = null;
        }

        /// <summary>
        /// 初始化对象
        /// </summary>
        /// <param name="obj"></param>
        public void Initialize(object obj)
        {
            m_Object = obj;
        }

        /// <summary>
        /// 获取对象
        /// </summary>
        public void Spawn()
        {
            OnSpawn();
            IsInUse = true;
        }

        /// <summary>
        /// 回收对象
        /// </summary>
        public void Unspawn()
        {
            OnUnspawn();
            IsInUse = false;
            LastUseTime = DateTime.UtcNow;
        }

        /// <summary>
        /// 释放对象
        /// </summary>
        public void Release()
        {
            OnRelease();
            m_Object = null;
        }

        /// <summary>
        /// 获取对象时的事件。
        /// </summary>
        protected virtual void OnSpawn()
        {

        }

        /// <summary>
        /// 回收对象时的事件。
        /// </summary>
        protected virtual void OnUnspawn()
        {

        }

        /// <summary>
        /// 释放对象时的事件
        /// </summary>
        protected virtual void OnRelease()
        {

        }
    }
}