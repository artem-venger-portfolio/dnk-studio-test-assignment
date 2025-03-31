using System;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ResourceLooter
{
    public class InputReceiver : MonoBehaviour
    {
        public event Action<bool> MovePressed;
        public event ScreenPositionHandler PointerPositionChanged;

        [UsedImplicitly]
        private void OnMove(InputValue inputValue)
        {
            MovePressed?.Invoke(inputValue.isPressed);
        }

        [UsedImplicitly]
        private void OnPointerPositionChanged(InputValue inputValue)
        {
            PointerPositionChanged?.Invoke(inputValue.Get<Vector2>());
        }
    }
}