using Cysharp.Threading.Tasks;
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
    }
}