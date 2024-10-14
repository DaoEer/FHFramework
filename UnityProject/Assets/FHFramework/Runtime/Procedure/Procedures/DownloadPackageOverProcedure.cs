namespace FHFramework
{
    public class DownloadPackageOverProcedure : Procedure
    {
        public override void OnEnter()
        {
            base.OnEnter();

            GameEntry.Procedure.ProcedureFsm.SwitchState<ClearPackageCacheProcedure>();
        }
    }
}