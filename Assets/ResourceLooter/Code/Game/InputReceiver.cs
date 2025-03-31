using System;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ResourceLooter
{
    public class InputReceiver : MonoBehaviour
    {
        public event Action MovePressed;
        public event Action<Vector2> PointerPositionChanged;

        [UsedImplicitly]
        private void OnMove(InputValue inputValue)
        {
            MovePressed?.Invoke();
        }

        [UsedImplicitly]
        private void OnPointerPositionChanged(InputValue inputValue)
        {
            PointerPositionChanged?.Invoke(inputValue.Get<Vector2>());
        }
    }
}