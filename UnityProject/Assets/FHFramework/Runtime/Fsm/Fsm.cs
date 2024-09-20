using System;
using System.Collections.Generic;
using System.Linq;

namespace FHFramework
{
    public class Fsm
    {
        private string m_Name;
        private Dictionary<Type, FsmState> m_States;
        private FsmState m_CurrentState;

        public string Name
        {
            get
            {
                return m_Name;
            }
        }
        public FsmState CurrentState
        {
            get
            {
                return m_CurrentState;
            }
        }

        public void Update(float elapseSeconds, float realElapseSeconds)
        {
            m_CurrentState?.OnUpdate();
        }

        public void SwitchState<T>() where T : FsmState
        {
            SwitchState(typeof(T));
        }

        public void SwitchState(Type stateType)
        {
            if (!m_States.TryGetValue(stateType, out FsmState targetState)) return;
            if (targetState.Equals(m_CurrentState)) return;
            m_CurrentState?.OnLeave();
            targetState.OnEnter();
            m_CurrentState = targetState;
        }

        public static Fsm Create(string name, params FsmState[] states)
        {
            return Create(name, states.ToArray());
        }

        public static Fsm Create(string name, IEnumerable<FsmState> states)
        {
            Fsm fsm = new()
            {
                m_Name = name,
                m_States = new Dictionary<Type, FsmState>()
            };

            foreach (FsmState state in states)
            {
                fsm.m_States.Add(state.GetType(), state);
            }

            return fsm;
        }
    }
}