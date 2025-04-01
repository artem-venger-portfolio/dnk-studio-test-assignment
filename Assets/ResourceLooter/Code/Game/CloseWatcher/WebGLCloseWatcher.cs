#if UNITY_WEBGL && !UNITY_EDITOR
using System.Runtime.InteropServices;
using JetBrains.Annotations;
using UnityEngine;

namespace System
{
    public class WebGLCloseWatcher : MonoBehaviour, ICloseWatcher
    {
        public event Action Closing;

        public static ICloseWatcher Create()
        {
            var go = new GameObject(nameof(WebGLCloseWatcher));
            var closeWatcher = go.AddComponent<WebGLCloseWatcher>();
            RegisterCloseHandler();

            return closeWatcher;
        }

        [DllImport(dllName: "__Internal")]
        private static extern void RegisterCloseHandler();

        [UsedImplicitly]
        private void OnWebGLClose()
        {
            Closing?.Invoke();
        }
    }
}
#endif