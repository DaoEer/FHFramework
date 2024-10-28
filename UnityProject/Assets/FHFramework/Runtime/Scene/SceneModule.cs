using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

namespace FHFramework
{
    public class SceneModule : FHFrameworkModule
    {
        private Dictionary<string, Scene> _loadedScene;

        protected override void Awake()
        {
            base.Awake();

            _loadedScene = new Dictionary<string, Scene>();
        }

        public async void LoadScene(string path)
        {
            if (_loadedScene.ContainsKey(path)) return;
            Scene scene = await GameEntry.Resource.LoadSceneAsync(path, LoadSceneMode.Additive);
            _loadedScene.Add(path, scene);
        }

        public async void UnloadScene(string path)
        {
            if (!_loadedScene.ContainsKey(path)) return;
            await SceneManager.UnloadSceneAsync(path);
        }
    }
}