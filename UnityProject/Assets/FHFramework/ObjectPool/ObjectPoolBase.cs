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
        /// �رն����
        /// </summary>
        public abstract void Shutdown();
    }
}