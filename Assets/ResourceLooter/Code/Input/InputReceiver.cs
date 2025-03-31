using System;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ResourceLooter
{
    public class InputReceiver : MonoBehaviour
    {
        public event Action MovePressed;

        [UsedImplicitly]
        private void OnMove(InputValue inputValue)
        {
            MovePressed?.Invoke();
        }
    }
}