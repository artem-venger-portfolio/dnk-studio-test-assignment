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
        private ICoroutineController _coroutineController;
        private Player _player;

        private void Start()
        {
            StartGame();
        }

        public void StartGame()
        {
            _coroutineController = CoroutineController.Create();
            _movePositionProvider = new MovePositionProvider(_inputReceiver, _camera, _ground);
            _movePositionProvider.Enable();
            var playerMover = new PlayerMover(_playerObject, _movePositionProvider, _coroutineController);
            _player = new Player(playerMover);
            _player.Enable();
        }
    }
}