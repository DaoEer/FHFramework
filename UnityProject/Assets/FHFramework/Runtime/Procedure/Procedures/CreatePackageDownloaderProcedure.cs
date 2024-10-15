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

            var packageName = GameEntry.Resource.DefaultPackageName;
            var package = YooAssets.GetPackage(packageName);
            int downloadingMaxNum = 10;
            int failedTryAgain = 3;
            var downloader = package.CreateResourceDownloader(downloadingMaxNum, failedTryAgain);

            if (downloader.TotalDownloadCount == 0)
            {
                LogHelper.LogInfo("Not found any download files !");
                GameEntry.Procedure.ProcedureFsm.SwitchState<UpdaterDoneProcedure>();
            }
            else
            {
                // �����¸����ļ��󣬹�������ϵͳ
                // ע�⣺��������Ҫ������ǰ�����̿ռ䲻��
                int totalDownloadCount = downloader.TotalDownloadCount;
                long totalDownloadBytes = downloader.TotalDownloadBytes;
                GameEntry.Procedure.ProcedureFsm.SwitchState<DownloadPackageFilesProcedure>();
            }
        }
    }
}