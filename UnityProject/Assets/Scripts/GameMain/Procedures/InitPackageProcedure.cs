using Cysharp.Threading.Tasks;
using FHFramework;
using YooAsset;

namespace GameMain
{
    public class InitPackageProcedure : Procedure
    {
        public override async void OnEnter()
        {
            LogHelper.LogInfo("InitPackageProcedure：初始化资源包流程");

            InitializationOperation initializationOperation = await GameEntry.Resource.InitPackage("Default");
            if (initializationOperation?.Status == EOperationStatus.Succeed)
            {
                switch (GameEntry.Resource.playMode)
                {
                    case EPlayMode.EditorSimulateMode:
                        {

                            break;
                        }
                    case EPlayMode.OfflinePlayMode:
                        {

                            break;
                        }
                    case EPlayMode.HostPlayMode:
                        {

                            break;
                        }
                    case EPlayMode.WebPlayMode:
                        {

                            break;
                        }
                }
            }
        }
    }
}