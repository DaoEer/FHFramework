using System;
using System.Collections.Generic;

namespace FHFramework
{
    public partial class ObjectPoolModule : FHFrameworkModule
    {
        private Dictionary<Type, ObjectPoolBase> m_Pools;

        /// <summary>
        /// ��ȡ����أ�������ز��������Զ�����
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="autoReleaseInterval">������Զ��ͷŶ���ʱ����</param>
        /// <param name="expireTime">�������ʱ��</param>
        /// <returns>����ز����ӿ�</returns>
        public IObjectPool<T> GetObjectPool<T>(float autoReleaseInterval = 30, float expireTime = 30) where T : PoolObjectBase
        {
            if (!m_Pools.TryGetValue(typeof(T), out ObjectPoolBase poolBase))
            {
                poolBase = InternalObjectPool<T>(autoReleaseInterval, expireTime);
            }

            return poolBase as IObjectPool<T>;
        }

        /// <summary>
        /// ��ȡ����أ�������ز��������Զ�����
        /// </summary>
        /// <param name="poolObjectType"></param>
        /// <param name="autoReleaseInterval">������Զ��ͷŶ���ʱ����</param>
        /// <param name="expireTime">�������ʱ��</param>
        /// <returns></returns>
        public ObjectPoolBase GetObjectPool(Type poolObjectType, float autoReleaseInterval = 30, float expireTime = 30)
        {
            if (!m_Pools.TryGetValue(poolObjectType, out ObjectPoolBase poolBase))
            {
                poolBase = InternalObjectPool(poolObjectType, autoReleaseInterval, expireTime);
            }

            return poolBase;
        }

        private ObjectPoolBase InternalObjectPool<T>(float autoReleaseInterval, float expireTime) where T : PoolObjectBase
        {
            ObjectPool<T> objectPool = new ObjectPool<T>(autoReleaseInterval, expireTime);
            m_Pools.Add(typeof(T), objectPool);
            return objectPool;
        }

        private ObjectPoolBase InternalObjectPool(Type poolObjectType, float autoReleaseInterval, float expireTime)
        {
            if (!typeof(PoolObjectBase).IsAssignableFrom(poolObjectType))
            {
                LogHelper.LogError($"Object type '{poolObjectType.FullName}' is invalid.");
                return null;
            }

            Type objectPoolType = typeof(ObjectPool<>).MakeGenericType(poolObjectType);
            ObjectPoolBase objectPool = (ObjectPoolBase)Activator.CreateInstance(objectPoolType, new object[] { autoReleaseInterval, expireTime });
            m_Pools.Add(poolObjectType, objectPool);
            return objectPool;
        }

        /// <summary>
        /// ������Ƿ����
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public bool HasObjectPool<T>() where T : PoolObjectBase
        {
            return m_Pools.ContainsKey(typeof(T));
        }
    }
}