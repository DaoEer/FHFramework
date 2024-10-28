using UnityEngine;

namespace FHFramework
{
    /// <summary>
    /// 游戏入口
    /// </summary>
    public partial class GameEntry : MonoBehaviour
    {
        private void Awake()
        {
            InitModules();
        }

        private void Update()
        {
            FHFrameworkEntry.Update();
        }
    }
}