using System;
using System.Collections.Generic;
using UnityEngine;

namespace FHFramework
{
    /// <summary>
    /// 框架入口
    /// </summary>
    public static class FHFrameworkEntry
    {
        private static Dictionary<Type, FHFrameworkModule> _moduleMap;
        private static LinkedList<FHFrameworkModule> _updateModules;

        static FHFrameworkEntry()
        {
            _moduleMap = new Dictionary<Type, FHFrameworkModule>();
            _updateModules = new LinkedList<FHFrameworkModule>();
        }

        public static void Update()
        {
            for (LinkedListNode<FHFrameworkModule> current = _updateModules.First; current != null; current = current.Next)
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
            return _moduleMap.GetValueOrDefault(type);
        }

        public static void RegisterModule(FHFrameworkModule module)
        {
            if (module == null)
            {
                LogHelper.LogError("FHFramework Module is invelid.");
                return;
            }

            if (_moduleMap.ContainsKey(module.GetType()))
            {
                LogHelper.LogError($"FHFramework Module {module.GetType()} is already exist.");
                return;
            }


            LinkedListNode<FHFrameworkModule> currentNode = _updateModules.First;
            if(currentNode == null)
            {
                _updateModules.AddLast(module);
                return;
            }

            while (currentNode != null)
            {
                if (module.Priority < currentNode.Value.Priority)
                {
                    _updateModules.AddBefore(currentNode, module);
                    break;
                }
                currentNode = currentNode.Next;
            }

            _moduleMap.Add(module.GetType(), module);
        }
    }
}