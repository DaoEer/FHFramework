using System;
using System.Collections.Generic;

namespace FHFramework
{
    /// <summary>
    /// ∂‘∂‘œÛ≥ÿ
    /// </summary>
    public class ObjectPool<T> : ObjectPoolBase, IObjectPool<T> where T : PoolObjectBase
    {
        private LinkedList<PoolObjectBase> m_PoolObjects;
        private Dictionary<object, PoolObjectBase> m_KeyValuePairs;

        public override Type ObjectType
        {
            get => typeof(T);
        }

        public ObjectPool()
        {
            m_PoolObjects = new LinkedList<PoolObjectBase>();
            m_KeyValuePairs = new Dictionary<object, PoolObjectBase>();
        }

        public void Register(T obj, bool spawned)
        {
            if (m_KeyValuePairs.ContainsKey(obj.Object))
            {
                return;
            }

            if (spawned) obj.Spawn();
            m_PoolObjects.AddLast(obj);
            m_KeyValuePairs.Add(obj.Object, obj);
        }

        public bool TrySpawn(out T obj)
        {
            obj = null;
            foreach (PoolObjectBase internalObject in m_PoolObjects)
            {
                if (!internalObject.IsInUse)
                {
                    internalObject.Spawn();
                    obj = internalObject as T;
                    return true;
                }
            }

            return false;
        }

        public void Unspawn(T obj)
        {
            Unspawn(obj.Object);
        }

        public void Unspawn(object obj)
        {           
            if (!m_KeyValuePairs.TryGetValue(obj, out PoolObjectBase poolObject))
            {
                return;
            }

            poolObject.Unspawn();
        }

        public override void Release()
        {
            foreach (PoolObjectBase poolObject in m_PoolObjects)
            {
                poolObject.Release();
                m_PoolObjects.Remove(poolObject);
                m_KeyValuePairs.Remove(poolObject);
            }
        }

        public override void Update()
        {

        }

        public override void Shutdown()
        {
            foreach (PoolObjectBase obj in m_PoolObjects)
            {
                obj.Release();
            }
            m_PoolObjects.Clear();
            m_KeyValuePairs.Clear();
        }
    }
}