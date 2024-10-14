using Cysharp.Threading.Tasks;
using YooAsset;

namespace FHFramework
{
    public class DownloadPackageFilesProcedure : Procedure
    {
        public override void OnEnter()
        {
            base.OnEnter();


        }

        private async UniTask BeginDownload()
        {
            var downloader = GameEntry.Resource.Downloader;
            //downloader.OnDownloadErrorCallback = PatchEventDefine.WebFileDownloadFailed.SendEventMessage;
            //downloader.OnDownloadProgressCallback = PatchEventDefine.DownloadProgressUpdate.SendEventMessage;
            downloader.BeginDownload();
            await downloader;

            // ¼ì²âÏÂÔØ½á¹û
            if (downloader.Status != EOperationStatus.Succeed) return;
            GameEntry.Procedure.ProcedureFsm.SwitchState<DownloadPackageOverProcedure>();
        }
    }
}