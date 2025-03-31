using System.Collections;
using UnityEngine;

namespace ResourceLooter
{
    public class CoroutineController : MonoBehaviour, ICoroutineController
    {
        public static ICoroutineController Create()
        {
            var go = new GameObject(nameof(CoroutineController));
            var coroutineController = go.AddComponent<CoroutineController>();

            return coroutineController;
        }

        public Coroutine Run(IEnumerator enumerator)
        {
            return StartCoroutine(enumerator);
        }

        public void Stop(Coroutine coroutine)
        {
            StopCoroutine(coroutine);
        }
    }
}