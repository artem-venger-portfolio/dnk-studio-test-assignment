using System;
using UnityEngine;

namespace ResourceLooter
{
    public class MovePositionProvider
    {
        private readonly InputReceiver _inputReceiver;
        private Vector2 _lastScreenPosition;

        public MovePositionProvider(InputReceiver inputReceiver)
        {
            _inputReceiver = inputReceiver;
        }

        public event Action<Vector3> PositionChanged;

        public void Enable()
        {
            _inputReceiver.MovePressed += MovePressedEventHandler;
            _inputReceiver.PointerPositionChanged += PointerPositionChanged;
        }

        public void Disable()
        {
            _inputReceiver.MovePressed -= MovePressedEventHandler;
            _inputReceiver.PointerPositionChanged -= PointerPositionChanged;
        }

        private void MovePressedEventHandler()
        {
            Debug.Log($"{nameof(MovePressedEventHandler)}: {_lastScreenPosition}");
            PositionChanged?.Invoke(Vector3.zero);
        }

        private void PointerPositionChanged(Vector2 screenPosition)
        {
            _lastScreenPosition = screenPosition;
        }
    }
}