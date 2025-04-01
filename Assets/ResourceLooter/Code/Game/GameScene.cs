using System;
using UnityEngine;

namespace ResourceLooter
{
    public class GameScene : MonoBehaviour
    {
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

        [SerializeField]
        private InputCatchingScreen _inputCatchingScreen;

        private ICoroutineController _coroutineController;
        private GroundPointFinder _groundPointFinder;
        private CameraMover _cameraMover;
        private Inventory _inventory;
        private Player _player;
        private ISaveManager _saveManager;
        private ICloseWatcher _closeWatcher;

        private void Start()
        {
            StartGame();
        }

        public void StartGame()
        {
            _closeWatcher = CreateCloseWatcher();
            _closeWatcher.Closing += ClosingEventHandler;

            _saveManager = new PlayerPrefsSaveManager();
            _saveManager.Load();

            SetFrameRate();

            _coroutineController = CoroutineController.Create();

            _groundPointFinder = new GroundPointFinder(_ground, _camera);

            _inventory = new Inventory();

            var playerMover = new PlayerMover(_playerView.CharacterController, _groundPointFinder, _coroutineController,
                                              _config.PlayerConfig, _inputCatchingScreen);
            var playerAnimationSwitcher = new PlayerAnimationSwitcher(playerMover, _playerView.Animator);
            var resourceExtractor = new ResourceExtractor(_playerView, _coroutineController);
            _player = new Player(playerMover, playerAnimationSwitcher, resourceExtractor);
            _player.Enable();

            _cameraMover = new CameraMover(_inputCatchingScreen, _camera.transform, _coroutineController,
                                           _groundPointFinder, _config.CameraConfig);
            _cameraMover.Enable();

            foreach (var currentBuilding in _buildings)
            {
                currentBuilding.Initialize(_inventory, _config);
            }

            _hud.Initialize(_inventoryScreen, _settingsScreen);
            _inventoryScreen.Initialize(_inventory);
            _settingsScreen.Initialize(_saveManager);
        }

        private static ICloseWatcher CreateCloseWatcher()
        {
            #if UNITY_WEBGL && !UNITY_EDITOR
            return WebGLCloseWatcher.Create();
            #elif UNITY_ANDROID && !UNITY_EDITOR
            return AndroidCloseWatcher.Create();
            #else
            return CommonCloseWatcher.Create();
            #endif
        }

        private void ClosingEventHandler()
        {
            _saveManager.Save();
        }

        private void SetFrameRate()
        {
            if (Application.isEditor == false)
            {
                Application.targetFrameRate = 60;
            }
        }
    }
}