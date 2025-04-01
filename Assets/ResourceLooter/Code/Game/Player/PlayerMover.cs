﻿using System;
using System.Collections;
using UnityEngine;

namespace ResourceLooter
{
    public class PlayerMover
    {
        private readonly ClickAndDragDetector _clickAndDragDetector;
        private readonly GroundPointFinder _groundPointFinder;
        private readonly ICoroutineController _coroutineController;
        private readonly Transform _playerObject;
        private readonly IGameConfig _config;
        private Vector3 _targetPosition;
        private Quaternion _targetRotation;
        private Coroutine _moveCoroutine;
        private Coroutine _rotateCoroutine;

        public PlayerMover(Transform playerObject, ClickAndDragDetector clickAndDragDetector,
                           GroundPointFinder groundPointFinder, ICoroutineController coroutineController,
                           IGameConfig config)
        {
            _playerObject = playerObject;
            _clickAndDragDetector = clickAndDragDetector;
            _groundPointFinder = groundPointFinder;
            _coroutineController = coroutineController;
            _config = config;
        }

        public event Action MovementStarted;

        public event Action MovementFinished;

        public void Enable()
        {
            _clickAndDragDetector.Clicked += ClickEventHandler;
        }

        public void Disable()
        {
            _clickAndDragDetector.Clicked -= ClickEventHandler;
        }

        private Vector3 PlayerPosition
        {
            get => _playerObject.position;
            set => _playerObject.position = value;
        }

        private Quaternion PlayerRotation
        {
            get => _playerObject.rotation;
            set => _playerObject.rotation = value;
        }

        private void ClickEventHandler(Vector2 screenPosition)
        {
            _targetPosition = _groundPointFinder.FindPointFromScreenPoint(screenPosition);
            _targetRotation = GetTargetRotation();

            _moveCoroutine ??= _coroutineController.Run(GetMoveCoroutine());
            _rotateCoroutine ??= _coroutineController.Run(GetRotateCoroutine());
        }

        private Quaternion GetTargetRotation()
        {
            return Quaternion.LookRotation(_targetPosition - PlayerPosition);
        }

        private IEnumerator GetRotateCoroutine()
        {
            const float acceptable_angle = 1f;

            while (GetAngleToTargetRotation() > acceptable_angle)
            {
                PlayerRotation = GetRotationDelta() * PlayerRotation;
                yield return null;
            }
            _rotateCoroutine = null;
        }

        private float GetAngleToTargetRotation()
        {
            return Quaternion.Angle(PlayerRotation, _targetRotation);
        }

        private Quaternion GetRotationDelta()
        {
            const float rotation_speed = 45f;
            var angleDeltaFromSpeedAndTime = rotation_speed * Time.deltaTime;
            var angleToTargetRotation = GetAngleToTargetRotation();
            var angleDelta = Mathf.Min(angleDeltaFromSpeedAndTime, angleToTargetRotation);
            var rotationDelta = Quaternion.AngleAxis(angleDelta, _playerObject.up);

            return rotationDelta;
        }

        private IEnumerator GetMoveCoroutine()
        {
            MovementStarted?.Invoke();

            const float acceptable_distance = 0.0001f;
            while (GetDistanceToTargetPosition() > acceptable_distance)
            {
                PlayerPosition += GetMoveDelta();
                yield return null;
            }

            _moveCoroutine = null;
            MovementFinished?.Invoke();
        }

        private float GetDistanceToTargetPosition()
        {
            return Vector3.Distance(PlayerPosition, _targetPosition);
        }

        private Vector3 GetMoveDelta()
        {
            var distanceDeltaFromSpeedAndTime = _config.PlayerSpeed * Time.deltaTime;
            var distanceToTargetPosition = GetDistanceToTargetPosition();
            var distanceDelta = Mathf.Min(distanceDeltaFromSpeedAndTime, distanceToTargetPosition);

            var direction = _targetPosition - PlayerPosition;
            direction.Normalize();
            var moveDelta = direction * distanceDelta;

            return moveDelta;
        }
    }
}