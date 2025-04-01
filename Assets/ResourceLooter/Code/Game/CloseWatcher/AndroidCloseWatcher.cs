using UnityEngine;

namespace System
{
    public class AndroidCloseWatcher : MonoBehaviour, ICloseWatcher
    {
        public event Action Closing;

        public static ICloseWatcher Create()
        {
            var go = new GameObject(nameof(AndroidCloseWatcher));
            var closeWatcher = go.AddComponent<AndroidCloseWatcher>();

            return closeWatcher;
        }

        private void OnApplicationPause(bool isPaused)
        {
            if (isPaused)
            {
                Closing?.Invoke();
            }
        }
    }
}