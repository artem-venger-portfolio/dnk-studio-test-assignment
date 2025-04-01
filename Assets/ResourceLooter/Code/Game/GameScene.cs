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
        private Animator _animator;

        [SerializeField]
        private GameConfigSO _config;

        private ClickAndDragDetector _clickAndDragDetector;
        private ICoroutineController _coroutineController;
        private GroundPointFinder _groundPointFinder;
        private CameraMover _cameraMover;
        private Player _player;

        private void Start()
        {
            StartGame();
        }

        public void StartGame()
        {
            _coroutineController = CoroutineController.Create();

            _clickAndDragDetector = new ClickAndDragDetector(_inputReceiver, _config);
            _clickAndDragDetector.Enable();

            _groundPointFinder = new GroundPointFinder(_ground, _camera);

            var playerMover = new PlayerMover(_playerObject, _clickAndDragDetector, _groundPointFinder,
                                              _coroutineController, _config);
            _player = new Player(playerMover);
            _player.Enable();

            _cameraMover = new CameraMover(_clickAndDragDetector, _camera.transform, _coroutineController,
                                           _groundPointFinder, _config.CameraConfig);
            _cameraMover.Enable();
        }
    }
}