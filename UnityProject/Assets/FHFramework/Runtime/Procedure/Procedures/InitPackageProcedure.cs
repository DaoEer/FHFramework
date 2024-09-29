using Cysharp.Threading.Tasks;
using YooAsset;

namespace FHFramework
{
    public class InitPackageProcedure : Procedure
    {
        public override void OnEnter()
        {
            LogHelper.Log(LogLevel.Log, "InitPackageProcedure：初始化资源包流程");
        }

        private async UniTask InitPackage()
        {
            InitializationOperation initializationOperation = GameEntry.Resource.InitPackage(ResourceModule.DefaultPackageName);
            await initializationOperation;
            if (!initializationOperation.Status.Equals(EOperationStatus.Succeed))
            {
                LogHelper.Log(LogLevel.Error, initializationOperation.Error);
            }
        }
    }
}
