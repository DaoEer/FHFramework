using System;

namespace FHFramework
{
    [AttributeUsage(AttributeTargets.Class)]
    public class PanelAttribute : Attribute
    {
        public string Location
        {
            get;
            private set;
        }

        public PanelAttribute(string location)
        {
            Location = location;
        }
    }
}