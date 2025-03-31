using System.Collections;
using UnityEngine;

namespace ResourceLooter
{
    public interface ICoroutineController
    {
        Coroutine Run(IEnumerator enumerator);
        void Stop(Coroutine coroutine);
    }
}