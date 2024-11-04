using Cysharp.Threading.Tasks;
using FHFramework;

namespace GameMain
{
    public class InitPackageProcedure : Procedure
    {
        public override void OnEnter()
        {
            LogHelper.LogInfo("InitPackageProcedure：初始化资源包流程");

            GameEntry.Resource.InitPackage("Default").Forget();
        }
    }
}