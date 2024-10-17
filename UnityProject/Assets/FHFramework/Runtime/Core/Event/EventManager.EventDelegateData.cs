using System;
using System.Collections.Generic;

namespace FHFramework
{
    public partial class EventManager
    {
        private class EventDelegateData
        {
            private readonly int m_Type;
            private readonly List<Delegate> m_ExistList;
            private readonly List<Delegate> m_AddList;
            private readonly List<Delegate> m_DeleteList;
            private bool m_IsExecute;
            private bool m_IsDirty;

            public EventDelegateData(int eventType)
            {
                m_Type = eventType;
                m_ExistList = new();
                m_AddList = new();
                m_DeleteList = new();
            }

            public bool AddHandler(Delegate @delegate)
            {
                if (m_ExistList.Contains(@delegate))
                {
                    LogHelper.LogWarning("Repeated Add Handler");
                    return false;
                }

                if (m_IsExecute)
                {
                    m_IsDirty = true;
                    m_AddList.Add(@delegate);
                }
                else
                {
                    m_ExistList.Add(@delegate);
                }

                return true;
            }

            public void RemoveHandler(Delegate @delegate)
            {
                if (m_IsExecute)
                {
                    m_IsDirty = true;
                    m_DeleteList.Add(@delegate);
                }
                else
                {
                    if (!m_ExistList.Remove(@delegate))
                    {
                        LogHelper.LogError($"Delete handle failed, not exist, EventId: {m_Type}");
                    }
                }
            }

            private void CheckModify()
            {
                m_IsExecute = false;
                if (m_IsDirty)
                {
                    for (int i = 0; i < m_AddList.Count; i++)
                    {
                        m_ExistList.Add(m_AddList[i]);
                    }

                    m_AddList.Clear();

                    for (int i = 0; i < m_DeleteList.Count; i++)
                    {
                        m_ExistList.Remove(m_DeleteList[i]);
                    }

                    m_DeleteList.Clear();
                }
            }

            public void Callback()
            {
                m_IsExecute = true;
                for (var i = 0; i < m_ExistList.Count; i++)
                {
                    var d = m_ExistList[i];
                    if (d is Action action)
                    {
                        action();
                    }
                }

                CheckModify();
            }

            public void Callback<TArg1>(TArg1 arg1)
            {
                m_IsExecute = true;
                for (var i = 0; i < m_ExistList.Count; i++)
                {
                    var d = m_ExistList[i];
                    if (d is Action<TArg1> action)
                    {
                        action(arg1);
                    }
                }
                CheckModify();
            }

            public void Callback<TArg1, TArg2>(TArg1 arg1, TArg2 arg2)
            {
                m_IsExecute = true;
                for (var i = 0; i < m_ExistList.Count; i++)
                {
                    var d = m_ExistList[i];
                    if (d is Action<TArg1, TArg2> action)
                    {
                        action(arg1, arg2);
                    }
                }

                CheckModify();
            }

            public void Callback<TArg1, TArg2, TArg3>(TArg1 arg1, TArg2 arg2, TArg3 arg3)
            {
                m_IsExecute = true;
                for (var i = 0; i < m_ExistList.Count; i++)
                {
                    var d = m_ExistList[i];
                    if (d is Action<TArg1, TArg2, TArg3> action)
                    {
                        action(arg1, arg2, arg3);
                    }
                }

                CheckModify();
            }

            public void Callback<TArg1, TArg2, TArg3, TArg4>(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4)
            {
                m_IsExecute = true;
                for (var i = 0; i < m_ExistList.Count; i++)
                {
                    var d = m_ExistList[i];
                    if (d is Action<TArg1, TArg2, TArg3, TArg4> action)
                    {
                        action(arg1, arg2, arg3, arg4);
                    }
                }

                CheckModify();
            }

            public void Callback<TArg1, TArg2, TArg3, TArg4, TArg5>(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5)
            {
                m_IsExecute = true;
                for (var i = 0; i < m_ExistList.Count; i++)
                {
                    var d = m_ExistList[i];
                    if (d is Action<TArg1, TArg2, TArg3, TArg4, TArg5> action)
                    {
                        action(arg1, arg2, arg3, arg4, arg5);
                    }
                }

                CheckModify();
            }

            public void Callback<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6)
            {
                m_IsExecute = true;
                for (var i = 0; i < m_ExistList.Count; i++)
                {
                    var d = m_ExistList[i];
                    if (d is Action<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6> action)
                    {
                        action(arg1, arg2, arg3, arg4, arg5, arg6);
                    }
                }

                CheckModify();
            }

            public void Callback<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7)
            {
                m_IsExecute = true;
                for (var i = 0; i < m_ExistList.Count; i++)
                {
                    var d = m_ExistList[i];
                    if (d is Action<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7> action)
                    {
                        action(arg1, arg2, arg3, arg4, arg5, arg6, arg7);
                    }
                }

                CheckModify();
            }

            public void Callback<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8)
            {
                m_IsExecute = true;
                for (var i = 0; i < m_ExistList.Count; i++)
                {
                    var d = m_ExistList[i];
                    if (d is Action<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8> action)
                    {
                        action(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
                    }
                }

                CheckModify();
            }
        }
    }
}