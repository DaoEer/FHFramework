using FHFramework;
using UnityEngine;

public class HotUpdateMonoBehaviourTest : MonoBehaviour
{
    public string cube;
    public string sphere;
    public string capsule;
    public string cylinder;

    private void Start()
    {
        Test();
    }

    public async void Test()
    {
        LogHelper.LogInfo("热更代码加载成功");
        GameObject cubeGameObject = await GameEntry.Resource.LoadAssetAsync<GameObject>(this.cube);
        GameObject sphereGameObject = await GameEntry.Resource.LoadAssetAsync<GameObject>(this.sphere);
        GameObject capsuleGameObject = await GameEntry.Resource.LoadAssetAsync<GameObject>(this.capsule);
        GameObject cylinderGameObject = await GameEntry.Resource.LoadAssetAsync<GameObject>(this.cylinder);
        Instantiate(cubeGameObject);
        Instantiate(sphereGameObject);
        Instantiate(capsuleGameObject);
        Instantiate(cylinderGameObject);
        LogHelper.LogInfo("热更资源加载成功");
    }
}
