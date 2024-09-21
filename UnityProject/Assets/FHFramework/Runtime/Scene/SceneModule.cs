using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

namespace FHFramework
{
    public class SceneModule : FHFrameworkModule
    {
        private Dictionary<string, Scene> m_LoadedScene;

        protected override void Awake()
        {
            base.Awake();

            m_LoadedScene = new Dictionary<string, Scene>();
        }

        public async void LoadScene(string path)
        {
            if (m_LoadedScene.ContainsKey(path)) return;
            Scene scene = await GameEntry.Resource.LoadSceneAsync(path, LoadSceneMode.Additive);
            m_LoadedScene.Add(path, scene);
        }

        public async void UnloadScene(string path)
        {
            if (!m_LoadedScene.ContainsKey(path)) return;
            await SceneManager.UnloadSceneAsync(path);
        }
    }
}