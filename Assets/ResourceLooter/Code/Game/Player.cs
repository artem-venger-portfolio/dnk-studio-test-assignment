using UnityEngine;

namespace ResourceLooter
{
    public class Player
    {
        private readonly MovePositionProvider _movePositionProvider;
        private readonly ICoroutineController _coroutineController;
        private readonly Transform _playerObject;

        public Player(Transform playerObject, MovePositionProvider movePositionProvider, 
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
            _playerObject.position = position;
        }
    }
}