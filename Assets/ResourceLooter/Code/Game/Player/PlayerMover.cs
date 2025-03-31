using System.Collections;
using UnityEngine;

namespace ResourceLooter
{
    public class PlayerMover
    {
        private readonly MovePositionProvider _movePositionProvider;
        private readonly ICoroutineController _coroutineController;
        private readonly Transform _playerObject;
        private Vector3 _targetPosition;
        private Coroutine _coroutine;

        public PlayerMover(Transform playerObject, MovePositionProvider movePositionProvider,
                           ICoroutineController coroutineController)
        {
            _playerObject = playerObject;
            _movePositionProvider = movePositionProvider;
            _coroutineController = coroutineController;
        }

        public void Enable()
        {
            _movePositionProvider.PositionChanged += PositionChangedEventHandler;
        }

        public void Disable()
        {
            _movePositionProvider.PositionChanged -= PositionChangedEventHandler;
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
            _playerObject.position = _targetPosition;
            _coroutine = null;
            yield break;
        }
    }
}