namespace FHFramework
{
    public class LaunchProcedure : Procedure
    {
        private const string HotUpdateDLL = "Assets/Assets/HotUpdate/DLL/HotUpdate.dll";
        private const string HotUpdateScene = "Assets/Assets/HotUpdate/Scenes/HorfixTest.unity";

        public override void OnEnter()
        {
            LogHelper.Log(LogLevel.Log, "LaunchProcedure：游戏启动流程");
        }

        private async void InitPackage()
        {
            
        }
    }
}
