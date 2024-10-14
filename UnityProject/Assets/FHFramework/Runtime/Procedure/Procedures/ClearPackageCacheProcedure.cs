using YooAsset;

namespace FHFramework
{
    public class ClearPackageCacheProcedure : Procedure
    {
        public override void OnEnter()
        {
            base.OnEnter();

            ResourcePackage package = YooAssets.GetPackage(GameEntry.Resource.DefaultPackageName);
            ClearUnusedBundleFilesOperation operation = package.ClearUnusedBundleFilesAsync();
            operation.Completed += operation => GameEntry.Procedure.ProcedureFsm.SwitchState<UpdaterDoneProcedure>();
        }
    }
}