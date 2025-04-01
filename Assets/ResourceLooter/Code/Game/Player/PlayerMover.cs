using System;
using System.Collections;
using UnityEngine;

namespace ResourceLooter
{
    public class PlayerMover
    {
        private readonly GroundPointFinder _groundPointFinder;
        private readonly ICoroutineController _coroutineController;
        private readonly CharacterController _characterController;
        private readonly Transform _playerTransform;
        private readonly PlayerConfig _config;
        private readonly InputCatchingScreen _inputCatchingScreen;
        private Vector3 _targetPosition;
        private Quaternion _targetRotation;
        private Coroutine _moveCoroutine;
        private Coroutine _rotateCoroutine;

        public PlayerMover(CharacterController characterController, GroundPointFinder groundPointFinder,
                           ICoroutineController coroutineController, PlayerConfig config,
                           InputCatchingScreen inputCatchingScreen)
        {
            _playerTransform = characterController.transform;
            _characterController = characterController;
            _groundPointFinder = groundPointFinder;
            _coroutineController = coroutineController;
            _config = config;
            _inputCatchingScreen = inputCatchingScreen;
        }

        public event Action MovementStarted;

        public event Action MovementFinished;

        public void Enable()
        {
            _inputCatchingScreen.Clicked += ClickEventHandler;
        }

        public void Disable()
        {
            _inputCatchingScreen.Clicked -= ClickEventHandler;
        }

        private Vector3 PlayerPosition => _playerTransform.position;

        private Quaternion PlayerRotation
        {
            get => _playerTransform.rotation;
            set => _playerTransform.rotation = value;
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
            return Quaternion.LookRotation(GetMoveDirection());
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
            var angleDeltaFromSpeedAndTime = _config.RotationSpeed * Time.deltaTime;
            var angleToTargetRotation = GetAngleToTargetRotation();
            var angleDelta = Mathf.Min(angleDeltaFromSpeedAndTime, angleToTargetRotation);

            var rotationAxis = Vector3.Cross(_playerTransform.forward, GetMoveDirection());
            var rotationDelta = Quaternion.AngleAxis(angleDelta, rotationAxis);

            return rotationDelta;
        }

        private IEnumerator GetMoveCoroutine()
        {
            MovementStarted?.Invoke();

            const float acceptable_distance = 0.001f;
            while (GetDistanceToTargetPosition() > acceptable_distance)
            {
                var motion = GetMoveDelta();
                _characterController.Move(motion);
                yield return null;
            }

            _moveCoroutine = null;
            MovementFinished?.Invoke();
        }

        private float GetDistanceToTargetPosition()
        {
            var targetPositionWithPlayerY = _targetPosition;
            targetPositionWithPlayerY.y = PlayerPosition.y;
            var distance = Vector3.Distance(PlayerPosition, targetPositionWithPlayerY);

            return distance;
        }

        private Vector3 GetMoveDelta()
        {
            var distanceDeltaFromSpeedAndTime = _config.MoveSpeed * Time.deltaTime;
            var distanceToTargetPosition = GetDistanceToTargetPosition();
            var distanceDelta = Mathf.Min(distanceDeltaFromSpeedAndTime, distanceToTargetPosition);

            var direction = GetMoveDirection();
            var moveDelta = direction * distanceDelta;

            return moveDelta;
        }

        private Vector3 GetMoveDirection()
        {
            var direction = _targetPosition - PlayerPosition;
            direction.y = 0;
            direction.Normalize();

            return direction;
        }
    }
}