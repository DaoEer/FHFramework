using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;
using YooAsset;

namespace FHFramework
{
    public partial class ResourceModule
    {
        public async UniTask<T> LoadAssetAsync<T>(string path) where T : UnityEngine.Object
        {
            AssetHandle handle = YooAssets.LoadAssetAsync<T>(path);
            await handle;
            return handle.AssetObject as T;
        }

        public T LoadAssetSync<T>(string path) where T : UnityEngine.Object
        {
            return YooAssets.LoadAssetSync<T>(path).AssetObject as T;
        }

        public async UniTask<Scene> LoadSceneAsync(string path, LoadSceneMode sceneMode = LoadSceneMode.Single, LocalPhysicsMode physicsMode = LocalPhysicsMode.None, bool suspendLoad = false, uint priority = 100)
        {
            SceneHandle handle = YooAssets.LoadSceneAsync(path, sceneMode, physicsMode, suspendLoad, priority);
            await handle;
            return handle.SceneObject;
        }

        public Scene LoadSceneSync(string path, LoadSceneMode sceneMode = LoadSceneMode.Single, LocalPhysicsMode physicsMode = LocalPhysicsMode.None)
        {
            return YooAssets.LoadSceneSync(path, sceneMode, physicsMode).SceneObject;
        }
    }
}