namespace FHFramework
{
    public class PoolObjectBase
    {
        private object m_Object;

        /// <summary>
        /// ��ȡ����
        /// </summary>
        public virtual object Object
        {
            get
            {
                return m_Object;
            }
        }

        /// <summary>
        /// ��ȡ�����Ƿ�����ʹ��
        /// </summary>
        public bool IsInUse
        {
            get;
            private set;
        }

        public PoolObjectBase()
        {
            m_Object = null;
        }

        /// <summary>
        /// ��ʼ������
        /// </summary>
        /// <param name="obj"></param>
        public void Initialize(object obj)
        {
            m_Object = obj;
        }

        /// <summary>
        /// ��ȡ����
        /// </summary>
        public void Spawn()
        {
            OnSpawn();
            IsInUse = true;
        }

        /// <summary>
        /// ���ն���
        /// </summary>
        public void Unspawn()
        {
            OnUnspawn();
            IsInUse = false;
        }

        /// <summary>
        /// �ͷŶ���
        /// </summary>
        public void Release()
        {
            OnRelease();
            m_Object = null;
        }

        /// <summary>
        /// ��ȡ����ʱ���¼���
        /// </summary>
        protected virtual void OnSpawn()
        {

        }

        /// <summary>
        /// ���ն���ʱ���¼���
        /// </summary>
        protected virtual void OnUnspawn()
        {

        }

        /// <summary>
        /// �ͷŶ���ʱ���¼�
        /// </summary>
        protected virtual void OnRelease()
        {

        }
    }
}