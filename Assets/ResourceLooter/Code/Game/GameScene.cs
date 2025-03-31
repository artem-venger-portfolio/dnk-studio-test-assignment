using UnityEngine;

namespace ResourceLooter
{
    public class GameScene : MonoBehaviour
    {
        [SerializeField]
        private InputReceiver _inputReceiver;

        [SerializeField]
        private Camera _camera;

        [SerializeField]
        private Transform _ground;

        [SerializeField]
        private Transform _playerObject;

        [SerializeField]
        private GameConfigSO _config;

        private MovePositionProvider _movePositionProvider;
        private Player _player;

        private void Start()
        {
            StartGame();
        }

        public void StartGame()
        {
            _movePositionProvider = new MovePositionProvider(_inputReceiver, _camera, _ground);
            _movePositionProvider.Enable();
            _player = new Player(_playerObject, _movePositionProvider);
            _player.Enable();
        }
    }
}