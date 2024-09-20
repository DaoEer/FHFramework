using System.Collections.Generic;
using UnityEngine;

namespace FHFramework
{
    public class FsmModule : FHFrameworkModule
    {
        private Dictionary<string, Fsm> m_Fsms;

        protected override void Awake()
        {
            base.Awake();
            m_Fsms = new Dictionary<string, Fsm>();
        }

        private void Update()
        {
            foreach (Fsm fsm in m_Fsms.Values)
            {
                fsm.Update(Time.deltaTime, Time.unscaledDeltaTime);
            }
        }

        public Fsm GetFsm(string name)
        {
            m_Fsms.TryGetValue(name, out Fsm fsm);
            return fsm;
        }

        public Fsm Create(string name, params FsmState[] states)
        {
            return Create(name, states);
        }

        public Fsm Create(string name, IEnumerable<FsmState> states)
        {
            if (m_Fsms.ContainsKey(name)) return null;
            return Fsm.Create(name, states);
        }
    }
}
