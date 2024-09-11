using System;
using System.Collections.Generic;

namespace FHFramework
{
    public partial class GameEntry
    {
        private static Dictionary<Type, FHFrameworkModule> m_ModuleMap;

        public static ResourceModule Resource => m_Resource;
        private static ResourceModule m_Resource;

        public T GetModule<T>() where T : FHFrameworkModule
        {
            return GetModule(typeof(T)) as T;
        }

        public FHFrameworkModule GetModule(Type type)
        {
            if(m_ModuleMap.TryGetValue(type, out FHFrameworkModule module))
            {
                return module;
            }

            return null;
        }

        public void RegisterModule(FHFrameworkModule module)
        {
            if (module == null) return;
            if (m_ModuleMap.ContainsKey(module.GetType())) return;
        }
    }
}