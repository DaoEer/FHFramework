using System;
using System.Collections.Generic;
using UnityEngine;

namespace FHFramework
{
    /// <summary>
    /// ÓÎÏ·¿ò¼ÜÈë¿Ú
    /// </summary>
    public static class FHFrameworkEntry
    {
        private static Dictionary<Type, FHFrameworkModule> m_ModuleMap;
        private static LinkedList<FHFrameworkModule> m_UpdateMosules;

        static FHFrameworkEntry()
        {
            m_ModuleMap = new Dictionary<Type, FHFrameworkModule>();
            m_UpdateMosules = new LinkedList<FHFrameworkModule>();
        }

        public static void Update()
        {
            for (LinkedListNode<FHFrameworkModule> current = m_UpdateMosules.First; current != null; current = current.Next)
            {
                current.Value.UpdateModule(Time.deltaTime, Time.unscaledDeltaTime);
            }
        }

        public static T GetModule<T>() where T : FHFrameworkModule
        {
            return GetModule(typeof(T)) as T;
        }

        public static FHFrameworkModule GetModule(Type type)
        {
            if (m_ModuleMap.TryGetValue(type, out FHFrameworkModule module))
            {
                return module;
            }

            return null;
        }

        public static void RegisterModule(FHFrameworkModule module)
        {
            if (module == null)
            {
                LogHelper.LogError("FHFramework Module is invelid.");
                return;
            }

            if (m_ModuleMap.ContainsKey(module.GetType()))
            {
                LogHelper.LogError($"FHFramework Module {module.GetType()} is already exist.");
                return;
            }


            LinkedListNode<FHFrameworkModule> currentNode = m_UpdateMosules.First;
            if(currentNode == null)
            {
                m_UpdateMosules.AddLast(module);
                return;
            }

            while (currentNode != null)
            {
                if (module.Priority < currentNode.Value.Priority)
                {
                    m_UpdateMosules.AddBefore(currentNode, module);
                    break;
                }
                currentNode = currentNode.Next;
            }

            m_ModuleMap.Add(module.GetType(), module);
        }
    }
}