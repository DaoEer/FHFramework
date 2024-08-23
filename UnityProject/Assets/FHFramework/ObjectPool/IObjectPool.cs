namespace FHFramework
{
    /// <summary>
    /// 对象池对外接口
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IObjectPool<T>
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
        /// 回收对象
        /// </summary>
        /// <param name="obj"></param>
        public void Unspawn(object obj);
    }
}