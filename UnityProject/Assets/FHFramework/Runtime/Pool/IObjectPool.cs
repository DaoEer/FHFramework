namespace FHFramework
{
    /// <summary>
    /// ����ض���ӿ�
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IObjectPool<T> where T : PoolObjectBase
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
        /// �ͷŶ���
        /// </summary>
        /// <param name="obj">Ҫ�ͷŵĶ���</param>
        /// <returns>�ͷŶ����Ƿ�ɹ���</returns>
        public bool ReleaseObject(T obj);

        /// <summary>
        /// ���ö����Ƿ񱻼�����
        /// </summary>
        /// <param name="obj">Ҫ���ñ������Ķ���</param>
        /// <param name="locked">�Ƿ񱻼�����</param>
        public void SetLocked(T obj, bool locked);
    }
}