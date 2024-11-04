using Cysharp.Threading.Tasks;
using FHFramework;
using YooAsset;

namespace GameMain
{
    public class UpdateVersionProcedure : Procedure
    {
        public override void OnEnter()
        {
            base.OnEnter();

            UpdatePackageVersion().Forget();
        }

        private async UniTask UpdatePackageVersion()
        {
            await UniTask.Delay(500);

            ResourcePackage package = YooAssets.GetPackage(GameEntry.Resource.defaultPackageName);
            RequestPackageVersionOperation operation = package.RequestPackageVersionAsync();
            await operation;

            if (operation.Status != EOperationStatus.Succeed)
            {
                LogHelper.LogError(operation.Error);
            }
            else
            {
                LogHelper.LogInfo($"Request package version : {operation.PackageVersion}");
                GameEntry.Resource.PackageVersion = operation.PackageVersion;
                GameEntry.Procedure.ProcedureFsm.SwitchState<UpdatePackageManifestProcedure>();
            }
        }
    }
}