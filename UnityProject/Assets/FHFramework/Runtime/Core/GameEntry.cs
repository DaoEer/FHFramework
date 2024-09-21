using UnityEngine;

namespace FHFramework
{
    /// <summary>
    /// сно╥хК©з
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