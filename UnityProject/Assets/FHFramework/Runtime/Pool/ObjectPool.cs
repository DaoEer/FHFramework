using System;
using System.Collections.Generic;
using UnityEngine;

namespace FHFramework
{
    /// <summary>
    /// 对象池
    /// </summary>
    public class ObjectPool<T> : ObjectPoolBase, IObjectPool<T> where T : PoolObjectBase
    {
        private LinkedList<PoolObjectBase> m_PoolObjects;
        private Dictionary<object, PoolObjectBase> m_ObjectMap;
        private List<T> m_CachedCanReleaseObjects;
        private float m_AutoReleaseInterval;
        private float m_ExpireTime;
        private float m_AutoReleaseTime;

        public override Type ObjectType
        {
            get => typeof(T);
        }

        /// <summary>
        /// 对象池
        /// </summary>
        /// <param name="autoReleaseInterval">自动释放对象的时间间隔</param>
        /// <param name="expireTime">对象过期时间</param>
        public ObjectPool(float autoReleaseInterval, float expireTime)
        {
            m_PoolObjects = new LinkedList<PoolObjectBase>();
            m_ObjectMap = new Dictionary<object, PoolObjectBase>();
            m_CachedCanReleaseObjects = new List<T>();
            m_AutoReleaseInterval = autoReleaseInterval;
            m_ExpireTime = expireTime;
            m_AutoReleaseTime = 0;
        }

        public override bool TryGetObject(object obj, out PoolObjectBase poolObject)
        {
            poolObject = null;
            if (obj == null)
            {
                LogHelper.LogError("Object is invalid.");
                return false;
            }

            if (!m_ObjectMap.TryGetValue(obj, out poolObject))
            {
                LogHelper.LogError("Object is not in pool.");
                return false;
            }

            return true;
        }

        public override void Release()
        {
            DateTime expireTime = DateTime.UtcNow.AddSeconds(-m_ExpireTime);
            List<PoolObjectBase> expiredObjects = new List<PoolObjectBase>();
            foreach (PoolObjectBase poolObject in m_PoolObjects)
            {
                if (poolObject.IsInUse || poolObject.IsLock) continue;
                if (poolObject.LastUseTime > expireTime) continue;
                expiredObjects.Add(poolObject);
            }

            foreach (PoolObjectBase poolObject in expiredObjects)
            {
                ReleaseObject(poolObject);
            }

            m_AutoReleaseTime = 0;
        }

        public override void Update()
        {
            m_AutoReleaseTime += Time.unscaledDeltaTime;
            if (m_AutoReleaseTime < m_AutoReleaseInterval) return;
            Release();
        }

        public override bool TrySpawn(out object obj)
        {
            obj = null;
            foreach (PoolObjectBase internalObject in m_PoolObjects)
            {
                if (!internalObject.IsInUse)
                {
                    internalObject.Spawn();
                    obj = internalObject;
                    return true;
                }
            }

            return false;
        }

        public override void Unspawn(object obj)
        {
            if (!TryGetObject(obj, out PoolObjectBase poolObject))
            {
                LogHelper.LogError("Object is not in pool.");
                return;
            }

            poolObject.Unspawn();
        }

        public override bool ReleaseObject(PoolObjectBase obj)
        {
            return ReleaseObject(obj.Object);
        }

        public override bool ReleaseObject(object obj)
        {
            if (!TryGetObject(obj, out PoolObjectBase poolObject)) return false;
            if (poolObject.IsInUse || poolObject.IsLock) return false;
            m_PoolObjects.Remove(poolObject);
            m_ObjectMap.Remove(poolObject.Object);
            poolObject.Release();
            return true;
        }

        public override void SetLocked(object obj, bool locked)
        {
            if (TryGetObject(obj, out PoolObjectBase poolObject))
            {
                poolObject.IsLock = locked;
            }
        }

        public override void Shutdown()
        {
            foreach (PoolObjectBase obj in m_PoolObjects)
            {
                obj.Release();
            }
            m_PoolObjects.Clear();
            m_ObjectMap.Clear();
        }

        public void Register(T obj, bool spawned)
        {
            if (m_ObjectMap.ContainsKey(obj.Object))
            {
                LogHelper.LogWarning("Object is already in pool.");
                return;
            }

            if (spawned) obj.Spawn();
            m_PoolObjects.AddLast(obj);
            m_ObjectMap.Add(obj.Object, obj);
        }

        public bool TrySpawn(out T obj)
        {
            bool isSpawn = TrySpawn(out object temp);
            obj = temp as T;
            return isSpawn;
        }

        public void Unspawn(T obj)
        {
            Unspawn(obj.Object);
        }

        public bool ReleaseObject(T obj)
        {
            return ReleaseObject(obj.Object);
        }

        public void SetLocked(T obj, bool locked)
        {
            SetLocked(obj.Object, locked);
        }
    }
}