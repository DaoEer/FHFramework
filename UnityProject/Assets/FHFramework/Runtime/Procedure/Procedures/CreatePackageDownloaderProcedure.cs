using Cysharp.Threading.Tasks;
using YooAsset;

namespace FHFramework
{
    public class CreatePackageDownloaderProcedure : Procedure
    {
        public override void OnEnter()
        {
            base.OnEnter();

            CreateDownloader().Forget();
        }

        private async UniTask CreateDownloader()
        {
            await UniTask.Delay(500);

            string packageName = GameEntry.Resource.defaultPackageName;
            ResourcePackage package = YooAssets.GetPackage(packageName);
            int downloadingMaxNum = 10;
            int failedTryAgain = 3;
            ResourceDownloaderOperation downloader = package.CreateResourceDownloader(downloadingMaxNum, failedTryAgain);

            if (downloader.TotalDownloadCount == 0)
            {
                LogHelper.LogInfo("Not found any download files !");
                GameEntry.Procedure.ProcedureFsm.SwitchState<UpdaterDoneProcedure>();
            }
            else
            {
                // 发现新更新文件后，挂起流程系统
                // 注意：开发者需要在下载前检测磁盘空间不足
                int totalDownloadCount = downloader.TotalDownloadCount;
                long totalDownloadBytes = downloader.TotalDownloadBytes;
                GameEntry.Procedure.ProcedureFsm.SwitchState<DownloadPackageFilesProcedure>();
            }
        }
    }
}