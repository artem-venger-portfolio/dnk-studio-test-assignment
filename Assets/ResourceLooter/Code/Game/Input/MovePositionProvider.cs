using System;
using UnityEngine;

namespace ResourceLooter
{
    public class MovePositionProvider
    {
        private readonly InputReceiver _inputReceiver;
        private readonly Camera _camera;
        private readonly Plane _plane;
        private Vector2 _lastScreenPosition;

        public MovePositionProvider(InputReceiver inputReceiver, Camera camera)
        {
            _inputReceiver = inputReceiver;
            _camera = camera;
            _plane = new Plane(Vector3.up, Vector3.zero);
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
            var lastWorldPosition = GetLastWorldPosition();
            PositionChanged?.Invoke(lastWorldPosition);
        }

        private Vector3 GetLastWorldPosition()
        {
            var ray = _camera.ScreenPointToRay(_lastScreenPosition);
            if (_plane.Raycast(ray, out var distance))
            {
                return ray.GetPoint(distance);
            }

            throw new Exception("Can't get the corresponding world position for the " +
                                $"last screen position {_lastScreenPosition}");
        }

        private void PointerPositionChanged(Vector2 screenPosition)
        {
            _lastScreenPosition = screenPosition;
        }
    }
}