using System;
using UnityEngine;

namespace ResourceLooter
{
    public class GroundPointFinder
    {
        private readonly Camera _camera;
        private readonly Plane _plane;

        public GroundPointFinder(Transform groundObject, Camera camera)
        {
            _plane = new Plane(groundObject.up, groundObject.position);
            _camera = camera;
        }

        public Vector3 FindPointFromScreenPoint(Vector2 screenPoint)
        {
            var ray = _camera.ScreenPointToRay(screenPoint);
            if (_plane.Raycast(ray, out var distance))
            {
                return ray.GetPoint(distance);
            }

            throw new Exception($"Can't get the corresponding world position for the screen position {screenPoint}");
        }
    }
}