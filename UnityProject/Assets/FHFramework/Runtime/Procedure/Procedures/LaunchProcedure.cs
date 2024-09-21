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
            LogHelper.Log(LogLevel.Log, "LaunchProcedure����Ϸ��������");

#if !UNITY_EDITOR
            // �����ȸ�����
            TextAsset dll = await GameEntry.Resource.LoadAssetAsync<TextAsset>(HotUpdateDLL);
            Assembly hotUpdateDLL = Assembly.Load(dll.bytes);
#endif

            // �����ȸ�����
            await GameEntry.Resource.LoadSceneAsync(HotUpdateScene);
        }
    }
}
