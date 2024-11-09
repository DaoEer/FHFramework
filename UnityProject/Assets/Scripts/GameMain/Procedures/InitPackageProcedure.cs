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
                switch (GameEntry.Resource.PlayMode)
                {
                    case EPlayMode.EditorSimulateMode:
                        {
                            GameEntry.Procedure.ProcedureFsm.SwitchState<TestProcedure>();
                            break;
                        }
                    case EPlayMode.OfflinePlayMode:
                        {
                            GameEntry.Procedure.ProcedureFsm.SwitchState<TestProcedure>();
                            break;
                        }
                    case EPlayMode.HostPlayMode:
                    case EPlayMode.WebPlayMode:
                        {
                            GameEntry.Procedure.ProcedureFsm.SwitchState<UpdateVersionProcedure>();
                            break;
                        }
                }
            }
        }
    }
}