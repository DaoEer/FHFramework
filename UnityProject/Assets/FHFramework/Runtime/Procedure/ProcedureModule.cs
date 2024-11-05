using System.Collections.Generic;

namespace FHFramework
{
    public class ProcedureModule : FHFrameworkModule
    {
        private List<Procedure> _procedures;

        private Fsm _procedureFsm;

        public Fsm ProcedureFsm
        {
            get
            {
                return _procedureFsm;
            }
        }

        public Procedure CurrentProcedure
        {
            get
            {
                return (Procedure)_procedureFsm.CurrentState;
            }
        }

        private void Start()
        {
            _procedureFsm = GameEntry.Fsm.Create("GameProcedure", _procedures);
        }
    }
}
