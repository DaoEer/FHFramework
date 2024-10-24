using System;

namespace FHFramework
{
    [AttributeUsage(AttributeTargets.Class)]
    public class PanelAttribute : Attribute
    {
        public string Path
        {
            get;
            private set;
        }

        public Type Logic
        {
            get;
            private set;
        }

        public PanelAttribute(string location, Type logicType)
        {
            Path = location;
            Logic = logicType;
        }
    }
}