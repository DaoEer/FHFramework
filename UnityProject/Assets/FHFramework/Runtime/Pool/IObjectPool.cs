namespace FHFramework
{
    /// <summary>
    /// 对象池对外接口
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IObjectPool<T> where T : PoolObjectBase
    {
        /// <summary>
        /// 创建对象
        /// </summary>
        /// <param name="obj">对象</param>
        /// <param name="spawned">对象是否已被获取</param>
        public void Register(T obj, bool spawned);

        /// <summary>
        /// 获取对象
        /// </summary>
        /// <returns></returns>
        public bool TrySpawn(out T obj);

        /// <summary>
        /// 回收对象
        /// </summary>
        /// <param name="obj"></param>
        public void Unspawn(T obj);

        /// <summary>
        /// 释放对象。
        /// </summary>
        /// <param name="obj">要释放的对象。</param>
        /// <returns>释放对象是否成功。</returns>
        public bool ReleaseObject(T obj);

        /// <summary>
        /// 设置对象是否被加锁。
        /// </summary>
        /// <param name="obj">要设置被加锁的对象。</param>
        /// <param name="locked">是否被加锁。</param>
        public void SetLocked(T obj, bool locked);
    }
}