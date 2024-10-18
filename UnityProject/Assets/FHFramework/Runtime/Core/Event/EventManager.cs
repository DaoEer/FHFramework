using System.Collections.Generic;

namespace FHFramework
{
    public partial class EventManager
    {
        private readonly Dictionary<int, EventDelegateData> m_EventTable;

        EventManager()
        {
            m_EventTable = new();
        }
    }
}