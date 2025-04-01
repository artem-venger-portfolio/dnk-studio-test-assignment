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
        private PlayerView _playerView;

        [SerializeField]
        private GameConfigSO _config;

        [SerializeField]
        private BuildingBase[] _buildings;

        [SerializeField]
        private HUD _hud;

        [SerializeField]
        private InventoryScreen _inventoryScreen;

        [SerializeField]
        private SettingsScreen _settingsScreen;

        private ClickAndDragDetector _clickAndDragDetector;
        private ICoroutineController _coroutineController;
        private GroundPointFinder _groundPointFinder;
        private CameraMover _cameraMover;
        private Inventory _inventory;
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

            _inventory = new Inventory();

            var playerMover = new PlayerMover(_playerView.CharacterController, _clickAndDragDetector,
                                              _groundPointFinder, _coroutineController, _config.PlayerConfig);
            var playerAnimationSwitcher = new PlayerAnimationSwitcher(playerMover, _playerView.Animator);
            var resourceExtractor = new ResourceExtractor(_playerView, _coroutineController);
            _player = new Player(playerMover, playerAnimationSwitcher, resourceExtractor);
            _player.Enable();

            _cameraMover = new CameraMover(_clickAndDragDetector, _camera.transform, _coroutineController,
                                           _groundPointFinder, _config.CameraConfig);
            _cameraMover.Enable();

            foreach (var currentBuilding in _buildings)
            {
                currentBuilding.Initialize(_inventory, _config);
            }

            _hud.Initialize(_inventoryScreen, _settingsScreen);
            _inventoryScreen.Initialize(_inventory);
            _settingsScreen.Initialize();
        }
    }
}