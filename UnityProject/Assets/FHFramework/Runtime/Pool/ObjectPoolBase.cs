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
        public abstract void Update();

        /// <summary>
        /// 尝试获取对象池对象
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="poolObject"></param>
        /// <returns></returns>
        public abstract bool TryGetObject(object obj, out PoolObjectBase poolObject);

        /// <summary>
        /// 获取对象
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public abstract bool TrySpawn(out object obj);

        /// <summary>
        /// 回收对象
        /// </summary>
        /// <param name="obj"></param>
        public abstract void Unspawn(object obj);

        /// <summary>
        /// 释放对象
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public abstract bool ReleaseObject(PoolObjectBase obj);

        /// <summary>
        /// 释放对象。
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>释放对象是否成功。</returns>
        public abstract bool ReleaseObject(object obj);

        /// <summary>
        /// 设置对象是否被加锁。
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="locked">是否被加锁。</param>
        public abstract void SetLocked(object obj, bool locked);

        /// <summary>
        /// 关闭对象池
        /// </summary>
        public abstract void Shutdown();
    }
}