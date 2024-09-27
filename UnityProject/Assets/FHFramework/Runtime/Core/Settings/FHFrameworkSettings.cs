using UnityEngine;

namespace FHFramework
{
    [CreateAssetMenu(fileName = "FHFrameworkSettings", menuName = "FHFramework/FHFrameworkSettings")]
    public partial class FHFrameworkSettings : ScriptableObject
    {
        [SerializeField]
        private FHFrameworkGlobalSettings m_GlobalSettings;
    }
}