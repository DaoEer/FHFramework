using System.Reflection;
using UnityEngine;

namespace FHFramework
{
    public class LaunchProcedure : Procedure
    {
        private const string HotUpdateDLL = "Assets/Assets/HotUpdate/DLL/HotUpdate.dll";
        private const string HotUpdateScene = "Assets/Assets/HotUpdate/Scenes/HorfixTest.unity";

        public override async void OnEnter()
        {
            LogHelper.Log(LogLevel.Log, "LaunchProcedure：游戏启动流程");

#if !UNITY_EDITOR
            // 加载热更代码
            TextAsset dll = await GameEntry.Resource.LoadAssetAsync<TextAsset>(HotUpdateDLL);
            Assembly hotUpdateDLL = Assembly.Load(dll.bytes);
#endif

            // 加载热更场景
            await GameEntry.Resource.LoadSceneAsync(HotUpdateScene);
        }
    }
}
