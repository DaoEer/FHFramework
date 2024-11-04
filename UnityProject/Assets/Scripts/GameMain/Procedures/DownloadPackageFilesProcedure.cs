using Cysharp.Threading.Tasks;
using FHFramework;
using YooAsset;

namespace GameMain
{
    public class DownloadPackageFilesProcedure : Procedure
    {
        public override void OnEnter()
        {
            base.OnEnter();


        }

        private async UniTask BeginDownload()
        {
            ResourceDownloaderOperation downloader = GameEntry.Resource.Downloader;
            //downloader.OnDownloadErrorCallback = PatchEventDefine.WebFileDownloadFailed.SendEventMessage;
            //downloader.OnDownloadProgressCallback = PatchEventDefine.DownloadProgressUpdate.SendEventMessage;
            downloader.BeginDownload();
            await downloader;

            // 检测下载结果
            if (downloader.Status != EOperationStatus.Succeed) return;
            GameEntry.Procedure.ProcedureFsm.SwitchState<DownloadPackageOverProcedure>();
        }
    }
}