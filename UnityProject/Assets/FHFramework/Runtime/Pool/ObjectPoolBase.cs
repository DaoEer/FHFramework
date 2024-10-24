using System;

namespace FHFramework
{
    /// <summary>
    /// ����ػ���
    /// </summary>
    public abstract class ObjectPoolBase
    {
        /// <summary>
        /// ���������
        /// </summary>
        public abstract Type ObjectType
        {
            get;
        }

        /// <summary>
        /// �ͷŶ�����ڿ����ͷŵĶ���
        /// </summary>
        public abstract void Release();

        /// <summary>
        /// �������ѯ
        /// </summary>
        /// <param name="deltaTime">Time.deltaTime</param>
        /// <param name="realDeltaTime">Time.unscaledDeltaTime</param>
        public abstract void Update();

        /// <summary>
        /// ���Ի�ȡ����ض���
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="poolObject"></param>
        /// <returns></returns>
        public abstract bool TryGetObject(object obj, out PoolObjectBase poolObject);

        /// <summary>
        /// ��ȡ����
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public abstract bool TrySpawn(out object obj);

        /// <summary>
        /// ���ն���
        /// </summary>
        /// <param name="obj"></param>
        public abstract void Unspawn(object obj);

        /// <summary>
        /// �ͷŶ���
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public abstract bool ReleaseObject(PoolObjectBase obj);

        /// <summary>
        /// �ͷŶ���
        /// </summary>
        /// <param name="target">Ҫ�ͷŵĶ���</param>
        /// <returns>�ͷŶ����Ƿ�ɹ���</returns>
        public abstract bool ReleaseObject(object obj);

        /// <summary>
        /// ���ö����Ƿ񱻼�����
        /// </summary>
        /// <param name="target">Ҫ���ñ������Ķ���</param>
        /// <param name="locked">�Ƿ񱻼�����</param>
        public abstract void SetLocked(object obj, bool locked);

        /// <summary>
        /// �رն����
        /// </summary>
        public abstract void Shutdown();
    }
}