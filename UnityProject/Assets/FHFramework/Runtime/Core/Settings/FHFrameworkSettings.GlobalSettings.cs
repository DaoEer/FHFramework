using System;
using System.Collections.Generic;
using UnityEngine;

namespace FHFramework
{
    public partial class FHFrameworkSettings
    {
        [Serializable]
        public class FHFrameworkGlobalSettings
        {
            [Header("Hotfix")]
            [SerializeField]
            private string HostServerURL = "http://127.0.0.1:8081";
            [SerializeField]
            private string FallbackHostServerURL = "http://127.0.0.1:8081";
            [SerializeField]
            private string WindowsUpdateDataUrl = "http://127.0.0.1";
            [SerializeField]
            private string MacOSUpdateDataUrl = "http://127.0.0.1";
            [SerializeField]
            private string IOSUpdateDataUrl = "http://127.0.0.1";
            [SerializeField]
            private string AndroidUpdateDataUrl = "http://127.0.0.1";
            [SerializeField]
            private string WebGLUpdateDataUrl = "http://127.0.0.1";
        }
    }
}