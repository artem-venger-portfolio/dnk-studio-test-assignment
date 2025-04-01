using UnityEngine;

namespace System
{
    public class CommonCloseWatcher : MonoBehaviour, ICloseWatcher
    {
        public event Action Closing;

        public static ICloseWatcher Create()
        {
            var go = new GameObject(nameof(CommonCloseWatcher));
            var closeWatcher = go.AddComponent<CommonCloseWatcher>();

            return closeWatcher;
        }

        private void OnApplicationQuit()
        {
            Closing?.Invoke();
        }
    }
}