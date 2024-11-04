using Cysharp.Threading.Tasks;
using FHFramework;
using YooAsset;

namespace GameMain
{
    public class UpdatePackageManifestProcedure : Procedure
    {
        public override void OnEnter()
        {
            base.OnEnter();

            UpdateManifest().Forget();
        }

        private async UniTask UpdateManifest()
        {
            await UniTask.Delay(500);

            string packageName = GameEntry.Resource.defaultPackageName;
            string packageVersion = GameEntry.Resource.PackageVersion;
            ResourcePackage package = YooAssets.GetPackage(packageName);
            UpdatePackageManifestOperation operation = package.UpdatePackageManifestAsync(packageVersion);
            await operation;

            if (operation.Status != EOperationStatus.Succeed)
            {
                LogHelper.LogInfo(operation.Error);
            }
            else
            {
                GameEntry.Procedure.ProcedureFsm.SwitchState<CreatePackageDownloaderProcedure>();
            }
        }
    }
}