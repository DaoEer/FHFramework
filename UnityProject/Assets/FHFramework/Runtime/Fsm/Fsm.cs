using System;
using System.Collections.Generic;

namespace FHFramework
{
    public class Fsm
    {
        private Dictionary<Type, FsmState> m_States;
        private FsmState m_CurrentState;

        private Fsm(string name, List<FsmState> states)
        {
            m_States = new Dictionary<Type, FsmState>();
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
            m_CurrentState?.OnExit();
            targetState.OnEnter();
            m_CurrentState = targetState;
        }

        public static Fsm Create(string name, List<FsmState> states)
        {
            return new Fsm(name, states);
        }
    }
}