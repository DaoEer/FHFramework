using FHFramework;
using UnityEngine;

public class HotUpdateMonoBehaviourTest : MonoBehaviour
{
    public string Cube;
    public string Sphere;
    public string Capsule;
    public string Cylinder;

    private void Start()
    {
        Test();
    }

    public async void Test()
    {
        LogHelper.LogInfo("热更代码加载成功");
        GameObject cube = await GameEntry.Resource.LoadAssetAsync<GameObject>(Cube);
        GameObject sphere = await GameEntry.Resource.LoadAssetAsync<GameObject>(Sphere);
        GameObject capsule = await GameEntry.Resource.LoadAssetAsync<GameObject>(Capsule);
        GameObject cylinder = await GameEntry.Resource.LoadAssetAsync<GameObject>(Cylinder);
        Instantiate(cube);
        Instantiate(sphere);
        Instantiate(capsule);
        Instantiate(cylinder);
        LogHelper.LogInfo("热更资源加载成功");
    }
}
