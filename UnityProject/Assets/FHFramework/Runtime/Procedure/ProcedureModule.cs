using System.Collections.Generic;

namespace FHFramework
{
    public class ProcedureModule : FHFrameworkModule
    {
        private List<Procedure> m_Procedures;

        private Fsm m_ProcedureFsm;

        public Fsm ProcedureFsm
        {
            get
            {
                return m_ProcedureFsm;
            }
        }

        public Procedure CurrentProcedure
        {
            get
            {
                return (Procedure)m_ProcedureFsm.CurrentState;
            }
        }

        protected override void Awake()
        {
            base.Awake();

            m_Procedures = new()
            {
                new InitPackageProcedure()
            };
        }

        private void Start()
        {
            m_ProcedureFsm = GameEntry.Fsm.Create("GameProcedure", m_Procedures);
            m_ProcedureFsm.SwitchState<InitPackageProcedure>();
        }
    }
}
