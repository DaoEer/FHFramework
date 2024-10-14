using Cysharp.Threading.Tasks;
using YooAsset;

namespace FHFramework
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

            var packageName = GameEntry.Resource.DefaultPackageName;
            var packageVersion = GameEntry.Resource.PackageVersion;
            var package = YooAssets.GetPackage(packageName);
            var operation = package.UpdatePackageManifestAsync(packageVersion);
            await operation;

            if (operation.Status != EOperationStatus.Succeed)
            {
                LogHelper.Log(LogLevel.Error, operation.Error);
                return;
            }
            else
            {
                GameEntry.Procedure.ProcedureFsm.SwitchState<CreatePackageDownloaderProcedure>();
            }
        }
    }
}