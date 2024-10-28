using System;
using System.Collections.Generic;

namespace FHFramework
{
    public class Fsm
    {
        private string _name;
        private Dictionary<Type, FsmState> _states;
        private FsmState _currentState;

        public string Name
        {
            get
            {
                return _name;
            }
        }
        public FsmState CurrentState
        {
            get
            {
                return _currentState;
            }
        }

        public void Update(float elapseSeconds, float realElapseSeconds)
        {
            _currentState?.OnUpdate();
        }

        public void SwitchState<T>() where T : FsmState
        {
            SwitchState(typeof(T));
        }

        public void SwitchState(Type stateType)
        {
            if (!_states.TryGetValue(stateType, out FsmState targetState)) return;
            if (targetState.Equals(_currentState)) return;
            _currentState?.OnLeave();
            targetState.OnEnter();
            _currentState = targetState;
        }

        public static Fsm Create(string name, params FsmState[] states)
        {
            return Create(name, (IEnumerable<FsmState>)states);
        }

        public static Fsm Create(string name, IEnumerable<FsmState> states)
        {
            Fsm fsm = new()
            {
                _name = name,
                _states = new Dictionary<Type, FsmState>()
            };

            foreach (FsmState state in states)
            {
                fsm._states.Add(state.GetType(), state);
            }

            return fsm;
        }
    }
}