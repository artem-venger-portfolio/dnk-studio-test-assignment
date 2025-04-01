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

        private ClickAndDragDetector _clickAndDragDetector;
        private MovePositionProvider _movePositionProvider;
        private ICoroutineController _coroutineController;
        private GroundPointFinder _groundPointFinder;
        private CameraMover _cameraMover;
        private Player _player;
        private Plane _groundPlane;

        private void Start()
        {
            StartGame();
        }

        public void StartGame()
        {
            _coroutineController = CoroutineController.Create();

            _clickAndDragDetector = new ClickAndDragDetector(_inputReceiver, _config);
            _clickAndDragDetector.Enable();

            _groundPlane = new Plane(_ground.up, _ground.position);
            _groundPointFinder = new GroundPointFinder(_ground, _camera);

            _movePositionProvider = new MovePositionProvider(_clickAndDragDetector, _camera, _groundPointFinder);
            _movePositionProvider.Enable();

            var playerMover = new PlayerMover(_playerObject, _movePositionProvider, _coroutineController, _config);
            _player = new Player(playerMover);
            _player.Enable();

            _cameraMover = new CameraMover(_clickAndDragDetector, _camera, _coroutineController, _groundPlane);
            _cameraMover.Enable();
        }
    }
}