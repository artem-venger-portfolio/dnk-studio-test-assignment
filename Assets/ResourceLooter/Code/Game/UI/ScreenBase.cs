using UnityEngine;

namespace ResourceLooter
{
    public abstract class ScreenBase : MonoBehaviour
    {
        public void Open()
        {
            gameObject.SetActive(value: true);
        }

        public void Close()
        {
            gameObject.SetActive(value: false);
        }
    }
}