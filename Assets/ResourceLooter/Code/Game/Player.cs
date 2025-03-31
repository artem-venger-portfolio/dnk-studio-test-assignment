using UnityEngine;

namespace ResourceLooter
{
    public class Player
    {
        private readonly MovePositionProvider _movePositionProvider;
        private readonly Transform _playerObject;

        public Player(Transform playerObject, MovePositionProvider movePositionProvider)
        {
            _playerObject = playerObject;
            _movePositionProvider = movePositionProvider;
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