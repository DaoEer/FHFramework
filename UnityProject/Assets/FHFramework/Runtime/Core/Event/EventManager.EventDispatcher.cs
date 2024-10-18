using System;

namespace FHFramework
{
    public partial class EventManager
    {
        public bool AddEventListener(int eventType, Delegate @delegate)
        {
            if (!m_EventTable.TryGetValue(eventType, out var data))
            {
                data = new EventDelegateData(eventType);
                m_EventTable.Add(eventType, data);
            }

            return data.AddHandler(@delegate);
        }

        public void RemoveEventListener(int eventType, Delegate @delegate)
        {
            if (m_EventTable.TryGetValue(eventType, out var data))
            {
                data.RemoveHandler(@delegate);
            }
        }

        public void Send(int eventType)
        {
            if (m_EventTable.TryGetValue(eventType, out var d))
            {
                d.Callback();
            }
        }

        public void Send<TArg1>(int eventType, TArg1 arg1)
        {
            if (m_EventTable.TryGetValue(eventType, out var d))
            {
                d.Callback(arg1);
            }
        }

        public void Send<TArg1, TArg2>(int eventType, TArg1 arg1, TArg2 arg2)
        {
            if (m_EventTable.TryGetValue(eventType, out var d))
            {
                d.Callback(arg1, arg2);
            }
        }

        public void Send<TArg1, TArg2, TArg3>(int eventType, TArg1 arg1, TArg2 arg2, TArg3 arg3)
        {
            if (m_EventTable.TryGetValue(eventType, out var d))
            {
                d.Callback(arg1, arg2, arg3);
            }
        }

        public void Send<TArg1, TArg2, TArg3, TArg4>(int eventType, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4)
        {
            if (m_EventTable.TryGetValue(eventType, out var d))
            {
                d.Callback(arg1, arg2, arg3, arg4);
            }
        }

        public void Send<TArg1, TArg2, TArg3, TArg4, TArg5>(int eventType, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5)
        {
            if (m_EventTable.TryGetValue(eventType, out var d))
            {
                d.Callback(arg1, arg2, arg3, arg4, arg5);
            }
        }

        public void Send<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(int eventType, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6)
        {
            if (m_EventTable.TryGetValue(eventType, out var d))
            {
                d.Callback(arg1, arg2, arg3, arg4, arg5, arg6);
            }
        }

        public void Send<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(int eventType, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7)
        {
            if (m_EventTable.TryGetValue(eventType, out var d))
            {
                d.Callback(arg1, arg2, arg3, arg4, arg5, arg6, arg7);
            }
        }

        public void Send<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(int eventType, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8)
        {
            if (m_EventTable.TryGetValue(eventType, out var d))
            {
                d.Callback(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
            }
        }
    }
}