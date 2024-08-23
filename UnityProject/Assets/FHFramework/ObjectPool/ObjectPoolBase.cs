using System;

namespace FHFramework
{
    /// <summary>
    /// 对象池基类
    /// </summary>
    public abstract class ObjectPoolBase
    {
        /// <summary>
        /// 对象池类型
        /// </summary>
        public abstract Type ObjectType
        {
            get;
        }

        /// <summary>
        /// 释放对象池内可以释放的对象
        /// </summary>
        public abstract void Release();

        /// <summary>
        /// 对象池轮询
        /// </summary>
        /// <param name="deltaTime">Time.deltaTime</param>
        /// <param name="realDeltaTime">Time.unscaledDeltaTime</param>
        public abstract void Update();

        /// <summary>
        /// 关闭对象池
        /// </summary>
        public abstract void Shutdown();
    }
}