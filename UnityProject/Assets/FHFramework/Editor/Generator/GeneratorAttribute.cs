using System;

namespace FHFramework
{
    [AttributeUsage(AttributeTargets.Class)]
    public class GeneratorAttribute : Attribute
    {
        public string Path
        {
            get;
            private set;
        }

        public GeneratorAttribute(string path)
        {
            Path = path;
        }
    }
}