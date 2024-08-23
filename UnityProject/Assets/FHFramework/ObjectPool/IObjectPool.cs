namespace FHFramework
{
    /// <summary>
    /// ����ض���ӿ�
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IObjectPool<T>
    {
        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="obj">����</param>
        /// <param name="spawned">�����Ƿ��ѱ���ȡ</param>
        public void Register(T obj, bool spawned);

        /// <summary>
        /// ��ȡ����
        /// </summary>
        /// <returns></returns>
        public bool TrySpawn(out T obj);

        /// <summary>
        /// ���ն���
        /// </summary>
        /// <param name="obj"></param>
        public void Unspawn(T obj);

        /// <summary>
        /// ���ն���
        /// </summary>
        /// <param name="obj"></param>
        public void Unspawn(object obj);
    }
}