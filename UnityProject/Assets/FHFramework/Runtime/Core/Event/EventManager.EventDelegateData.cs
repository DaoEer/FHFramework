using System;
using System.Collections.Generic;

namespace FHFramework
{
    public partial class EventManager
    {
        private class EventDelegateData
        {
            private readonly int _type;
            private readonly List<Delegate> _existList;
            private readonly List<Delegate> _addList;
            private readonly List<Delegate> _deleteList;
            private bool _isExecute;
            private bool _isDirty;

            public EventDelegateData(int eventType)
            {
                _type = eventType;
                _existList = new List<Delegate>();
                _addList = new List<Delegate>();
                _deleteList = new List<Delegate>();
            }

            public bool AddHandler(Delegate @delegate)
            {
                if (_existList.Contains(@delegate))
                {
                    LogHelper.LogWarning("Repeated Add Handler");
                    return false;
                }

                if (_isExecute)
                {
                    _isDirty = true;
                    _addList.Add(@delegate);
                }
                else
                {
                    _existList.Add(@delegate);
                }

                return true;
            }

            public void RemoveHandler(Delegate @delegate)
            {
                if (_isExecute)
                {
                    _isDirty = true;
                    _deleteList.Add(@delegate);
                }
                else
                {
                    if (!_existList.Remove(@delegate))
                    {
                        LogHelper.LogError($"Delete handle failed, not exist, EventId: {_type}");
                    }
                }
            }

            private void CheckModify()
            {
                _isExecute = false;
                if (_isDirty)
                {
                    for (int i = 0; i < _addList.Count; i++)
                    {
                        _existList.Add(_addList[i]);
                    }

                    _addList.Clear();

                    for (int i = 0; i < _deleteList.Count; i++)
                    {
                        _existList.Remove(_deleteList[i]);
                    }

                    _deleteList.Clear();
                }
            }

            public void Callback()
            {
                _isExecute = true;
                for (var i = 0; i < _existList.Count; i++)
                {
                    var d = _existList[i];
                    if (d is Action action)
                    {
                        action();
                    }
                }

                CheckModify();
            }

            public void Callback<TArg1>(TArg1 arg1)
            {
                _isExecute = true;
                for (var i = 0; i < _existList.Count; i++)
                {
                    var d = _existList[i];
                    if (d is Action<TArg1> action)
                    {
                        action(arg1);
                    }
                }
                CheckModify();
            }

            public void Callback<TArg1, TArg2>(TArg1 arg1, TArg2 arg2)
            {
                _isExecute = true;
                for (var i = 0; i < _existList.Count; i++)
                {
                    var d = _existList[i];
                    if (d is Action<TArg1, TArg2> action)
                    {
                        action(arg1, arg2);
                    }
                }

                CheckModify();
            }

            public void Callback<TArg1, TArg2, TArg3>(TArg1 arg1, TArg2 arg2, TArg3 arg3)
            {
                _isExecute = true;
                for (var i = 0; i < _existList.Count; i++)
                {
                    var d = _existList[i];
                    if (d is Action<TArg1, TArg2, TArg3> action)
                    {
                        action(arg1, arg2, arg3);
                    }
                }

                CheckModify();
            }

            public void Callback<TArg1, TArg2, TArg3, TArg4>(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4)
            {
                _isExecute = true;
                for (var i = 0; i < _existList.Count; i++)
                {
                    var d = _existList[i];
                    if (d is Action<TArg1, TArg2, TArg3, TArg4> action)
                    {
                        action(arg1, arg2, arg3, arg4);
                    }
                }

                CheckModify();
            }

            public void Callback<TArg1, TArg2, TArg3, TArg4, TArg5>(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5)
            {
                _isExecute = true;
                for (var i = 0; i < _existList.Count; i++)
                {
                    var d = _existList[i];
                    if (d is Action<TArg1, TArg2, TArg3, TArg4, TArg5> action)
                    {
                        action(arg1, arg2, arg3, arg4, arg5);
                    }
                }

                CheckModify();
            }

            public void Callback<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6)
            {
                _isExecute = true;
                for (var i = 0; i < _existList.Count; i++)
                {
                    var d = _existList[i];
                    if (d is Action<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6> action)
                    {
                        action(arg1, arg2, arg3, arg4, arg5, arg6);
                    }
                }

                CheckModify();
            }

            public void Callback<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7)
            {
                _isExecute = true;
                for (var i = 0; i < _existList.Count; i++)
                {
                    var d = _existList[i];
                    if (d is Action<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7> action)
                    {
                        action(arg1, arg2, arg3, arg4, arg5, arg6, arg7);
                    }
                }

                CheckModify();
            }

            public void Callback<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8)
            {
                _isExecute = true;
                for (var i = 0; i < _existList.Count; i++)
                {
                    var d = _existList[i];
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