using System;
using UnityEngine;

namespace ResourceLooter
{
    public class MovePositionProvider
    {
        private readonly ClickAndDragDetector _clickAndDragDetector;
        private readonly Camera _camera;
        private readonly Plane _plane;

        public MovePositionProvider(ClickAndDragDetector clickAndDragDetector, Camera camera, Transform ground)
        {
            _clickAndDragDetector = clickAndDragDetector;
            _camera = camera;
            _plane = new Plane(ground.up, ground.position);
        }

        public event Action<Vector3> PositionChanged;

        public void Enable()
        {
            _clickAndDragDetector.Clicked += ClickEventHandler;
        }

        public void Disable()
        {
            _clickAndDragDetector.Clicked -= ClickEventHandler;
        }

        private void ClickEventHandler(Vector2 screenPosition)
        {
            var worldPosition = GetWorldPosition(screenPosition);
            PositionChanged?.Invoke(worldPosition);
        }

        private Vector3 GetWorldPosition(Vector2 screenPosition)
        {
            var ray = _camera.ScreenPointToRay(screenPosition);
            if (_plane.Raycast(ray, out var distance))
            {
                return ray.GetPoint(distance);
            }

            throw new Exception("Can't get the corresponding world position for the " +
                                $"last screen position {screenPosition}");
        }
    }
}