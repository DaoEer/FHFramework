using FHFramework;

namespace GameMain
{
    public class ClearPackageCacheProcedure : Procedure
    {
        public override void OnEnter()
        {
            base.OnEnter();

            // ResourcePackage package = YooAssets.GetPackage(GameEntry.Resource.defaultPackageName);
            // ClearUnusedBundleFilesOperation operation = package.ClearUnusedBundleFilesAsync();
            // operation.Completed += operationBase => GameEntry.Procedure.ProcedureFsm.SwitchState<UpdaterDoneProcedure>();
        }
    }
}