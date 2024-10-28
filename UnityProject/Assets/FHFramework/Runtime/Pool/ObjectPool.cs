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
        private LinkedList<PoolObjectBase> _poolObjects;
        private Dictionary<object, PoolObjectBase> _objectMap;
        private List<T> _cachedCanReleaseObjects;
        private float _autoReleaseInterval;
        private float _expireTime;
        private float _autoReleaseTime;

        public override Type ObjectType
        {
            get
            {
                return typeof(T);
            }
        }

        /// <summary>
        /// 对象池
        /// </summary>
        /// <param name="autoReleaseInterval">自动释放对象的时间间隔</param>
        /// <param name="expireTime">对象过期时间</param>
        public ObjectPool(float autoReleaseInterval, float expireTime)
        {
            _poolObjects = new LinkedList<PoolObjectBase>();
            _objectMap = new Dictionary<object, PoolObjectBase>();
            _cachedCanReleaseObjects = new List<T>();
            _autoReleaseInterval = autoReleaseInterval;
            _expireTime = expireTime;
            _autoReleaseTime = 0;
        }

        public override bool TryGetObject(object obj, out PoolObjectBase poolObject)
        {
            poolObject = null;
            if (obj == null)
            {
                LogHelper.LogError("Object is invalid.");
                return false;
            }

            if (!_objectMap.TryGetValue(obj, out poolObject))
            {
                LogHelper.LogError("Object is not in pool.");
                return false;
            }

            return true;
        }

        public override void Release()
        {
            DateTime expireTime = DateTime.UtcNow.AddSeconds(-_expireTime);
            List<PoolObjectBase> expiredObjects = new List<PoolObjectBase>();
            foreach (PoolObjectBase poolObject in _poolObjects)
            {
                if (poolObject.IsInUse || poolObject.IsLock) continue;
                if (poolObject.LastUseTime > expireTime) continue;
                expiredObjects.Add(poolObject);
            }

            foreach (PoolObjectBase poolObject in expiredObjects)
            {
                ReleaseObject(poolObject);
            }

            _autoReleaseTime = 0;
        }

        public override void Update()
        {
            _autoReleaseTime += Time.unscaledDeltaTime;
            if (_autoReleaseTime < _autoReleaseInterval) return;
            Release();
        }

        public override bool TrySpawn(out object obj)
        {
            obj = null;
            foreach (PoolObjectBase internalObject in _poolObjects)
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
            _poolObjects.Remove(poolObject);
            _objectMap.Remove(poolObject.Object);
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
            foreach (PoolObjectBase obj in _poolObjects)
            {
                obj.Release();
            }

            _poolObjects.Clear();
            _objectMap.Clear();
        }

        public void Register(T obj, bool spawned)
        {
            if (_objectMap.ContainsKey(obj.Object))
            {
                LogHelper.LogWarning("Object is already in pool.");
                return;
            }

            if (spawned) obj.Spawn();
            _poolObjects.AddLast(obj);
            _objectMap.Add(obj.Object, obj);
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