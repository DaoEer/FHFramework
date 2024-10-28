using System.Collections.Generic;
using UnityEngine;

namespace FHFramework
{
    public class FsmModule : FHFrameworkModule
    {
        private Dictionary<string, Fsm> _fsms;

        protected override void Awake()
        {
            base.Awake();
            _fsms = new Dictionary<string, Fsm>();
        }

        private void Update()
        {
            foreach (Fsm fsm in _fsms.Values)
            {
                fsm.Update(Time.deltaTime, Time.unscaledDeltaTime);
            }
        }

        public Fsm GetFsm(string fsmName)
        {
            _fsms.TryGetValue(fsmName, out Fsm fsm);
            return fsm;
        }

        public Fsm Create(string fsmName, params FsmState[] states)
        {
            return Create(fsmName, (IEnumerable<FsmState>)states);
        }

        public Fsm Create(string fsmName, IEnumerable<FsmState> states)
        {
            if (_fsms.TryGetValue(fsmName, out Fsm fsm)) return fsm;
            fsm = Fsm.Create(fsmName, states);
            _fsms.Add(fsmName, fsm);
            return fsm;
        }
    }
}
