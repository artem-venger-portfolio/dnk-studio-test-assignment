using System;
using UnityEngine;

namespace ResourceLooter
{
    public class MovePositionProvider
    {
        private readonly ClickAndDragDetector _clickAndDragDetector;
        private readonly GroundPointFinder _groundPointFinder;
        private readonly Camera _camera;
        private readonly Plane _ground;

        public MovePositionProvider(ClickAndDragDetector clickAndDragDetector, Camera camera, 
                                    GroundPointFinder groundPointFinder)
        {
            _clickAndDragDetector = clickAndDragDetector;
            _groundPointFinder = groundPointFinder;
            _camera = camera;
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
            var worldPosition = _groundPointFinder.FindPointFromScreenPoint(screenPosition);
            PositionChanged?.Invoke(worldPosition);
        }
    }
}