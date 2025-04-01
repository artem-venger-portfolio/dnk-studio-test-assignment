using System.Collections;
using UnityEngine;

namespace ResourceLooter
{
    public class CameraMover
    {
        private readonly ClickAndDragDetector _clickAndDragDetector;
        private readonly ICoroutineController _coroutineController;
        private readonly Plane _ground;
        private readonly Camera _camera;
        private Coroutine _moveCoroutine;
        private Vector3 _startDragPosition;
        private Vector3 _targetPosition;
        private Vector3 _velocity;
        private bool _isDragging;

        public CameraMover(ClickAndDragDetector clickAndDragDetector, Camera camera,
                           ICoroutineController coroutineController, Plane ground)
        {
            _clickAndDragDetector = clickAndDragDetector;
            _coroutineController = coroutineController;
            _ground = ground;
            _camera = camera;
        }

        public void Enable()
        {
            _clickAndDragDetector.DragStarted += DragStartedEventHandler;
            _clickAndDragDetector.Dragging += DraggingEventHandler;
            _clickAndDragDetector.DragFinished += DragFinishedEventHandler;
        }

        public void Disable()
        {
            _clickAndDragDetector.DragStarted -= DragStartedEventHandler;
            _clickAndDragDetector.Dragging -= DraggingEventHandler;
            _clickAndDragDetector.DragFinished -= DragFinishedEventHandler;
        }

        private Vector3 CameraPosition
        {
            get => _camera.transform.position;
            set => _camera.transform.position = value;
        }

        private void DragStartedEventHandler(Vector2 screenPosition)
        {
            _isDragging = true;
            _startDragPosition = GetWorldPositionWithCameraY(screenPosition);
            RunMoveCoroutine();
        }

        private void DraggingEventHandler(Vector2 screenPosition)
        {
            var worldPosition = GetWorldPositionWithCameraY(screenPosition);
            var delta = worldPosition - _startDragPosition;
            _targetPosition = CameraPosition - delta;
        }

        private void DragFinishedEventHandler(Vector2 screenPosition)
        {
            _isDragging = false;
        }

        private void RunMoveCoroutine()
        {
            if (_moveCoroutine != null)
            {
                _coroutineController.Stop(_moveCoroutine);
            }
            _moveCoroutine = _coroutineController.Run(GetMoveCoroutine());
        }

        private Vector3 GetWorldPositionWithCameraY(Vector2 screenPosition)
        {
            var worldPosition = _camera.ScreenToWorldPoint(screenPosition);
            worldPosition.y = CameraPosition.y;

            return worldPosition;
        }

        private IEnumerator GetMoveCoroutine()
        {
            _targetPosition = CameraPosition;
            _velocity = Vector3.zero;

            while (_isDragging)
            {
                var distanceToTarget = Vector3.Distance(CameraPosition, _targetPosition);
                const float acceptable_distance = 0.0001f;
                var isOnTarget = distanceToTarget < acceptable_distance;
                if (isOnTarget == false)
                {
                    const float follow_time = 0.5f;
                    CameraPosition = Vector3.SmoothDamp(CameraPosition, _targetPosition, ref _velocity, follow_time);
                }

                yield return null;
            }

            var acceleration = Vector3.zero;
            const float max_acceleration = float.PositiveInfinity;
            const float min_deceleration_velocity = 0.5f;
            while (_velocity.magnitude > min_deceleration_velocity)
            {
                var deltaTime = Time.deltaTime;
                CameraPosition += _velocity * deltaTime;
                const float deceleration_time = 1f;
                _velocity = Vector3.SmoothDamp(_velocity, Vector3.zero, ref acceleration, deceleration_time,
                                               max_acceleration, deltaTime);
                yield return null;
            }

            _moveCoroutine = null;
        }
    }
}