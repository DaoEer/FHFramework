using System.Collections.Generic;

namespace FHFramework
{
    public partial class EventManager
    {
        private readonly Dictionary<int, EventDelegateData> _eventTable;

        EventManager()
        {
            _eventTable = new Dictionary<int, EventDelegateData>();
        }
    }
}