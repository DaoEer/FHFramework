using UnityEngine;

namespace FHFramework
{
    /// <summary>
    /// ��Ϸ���
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