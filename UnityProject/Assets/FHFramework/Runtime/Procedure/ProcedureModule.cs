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

        protected override void Awake()
        {
            base.Awake();

            _procedures = new List<Procedure>
            {
                new InitPackageProcedure(),
                new UpdateVersionProcedure(),
                new UpdatePackageManifestProcedure(),
                new CreatePackageDownloaderProcedure(),
                new DownloadPackageFilesProcedure(),
                new DownloadPackageOverProcedure(),
                new ClearPackageCacheProcedure(),
                new UpdaterDoneProcedure(),
                new TestProcedure()
            };
        }

        private void Start()
        {
            _procedureFsm = GameEntry.Fsm.Create("GameProcedure", _procedures);
            _procedureFsm.SwitchState<TestProcedure>();
        }
    }
}
