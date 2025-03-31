﻿using System.Collections;
using UnityEngine;

namespace ResourceLooter
{
    public class PlayerMover
    {
        private readonly MovePositionProvider _movePositionProvider;
        private readonly ICoroutineController _coroutineController;
        private readonly Transform _playerObject;
        private readonly IGameConfig _config;
        private Vector3 _targetPosition;
        private Coroutine _coroutine;

        public PlayerMover(Transform playerObject, MovePositionProvider movePositionProvider,
                           ICoroutineController coroutineController, IGameConfig config)
        {
            _playerObject = playerObject;
            _movePositionProvider = movePositionProvider;
            _coroutineController = coroutineController;
            _config = config;
        }

        public void Enable()
        {
            _movePositionProvider.PositionChanged += PositionChangedEventHandler;
        }

        public void Disable()
        {
            _movePositionProvider.PositionChanged -= PositionChangedEventHandler;
        }

        private Vector3 PlayerPosition
        {
            get => _playerObject.position;
            set => _playerObject.position = value;
        }

        private void PositionChangedEventHandler(Vector3 position)
        {
            _targetPosition = position;

            if (_coroutine != null)
            {
                _coroutineController.Stop(_coroutine);
            }

            _coroutine = _coroutineController.Run(GetMoveCoroutine());
        }

        private IEnumerator GetMoveCoroutine()
        {
            const float acceptable_distance = 0.0001f;

            while (GetDistanceToTargetPosition() > acceptable_distance)
            {
                PlayerPosition += GetMoveDelta();
                yield return null;
            }

            _coroutine = null;
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