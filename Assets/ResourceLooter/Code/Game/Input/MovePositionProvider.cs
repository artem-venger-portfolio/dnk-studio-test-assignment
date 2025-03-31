using System;
using UnityEngine;

namespace ResourceLooter
{
    public class MovePositionProvider
    {
        private readonly InputReceiver _inputReceiver;
        private readonly Camera _camera;
        private Vector2 _lastScreenPosition;

        public MovePositionProvider(InputReceiver inputReceiver, Camera camera)
        {
            _inputReceiver = inputReceiver;
            _camera = camera;
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
            var lastWorldPosition = _camera.ScreenToWorldPoint(_lastScreenPosition);
            PositionChanged?.Invoke(lastWorldPosition);
        }

        private void PointerPositionChanged(Vector2 screenPosition)
        {
            _lastScreenPosition = screenPosition;
        }
    }
}