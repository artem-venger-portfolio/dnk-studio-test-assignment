using UnityEngine;
using UnityEngine.UI;

namespace ResourceLooter
{
    public class HUD : ScreenBase
    {
        [SerializeField]
        private Button _settingsButton;

        [SerializeField]
        private Button _inventoryButton;

        private InventoryScreen _inventoryScreen;
        private SettingsScreen _settingsScreen;

        public void Initialize(InventoryScreen inventoryScreen, SettingsScreen settingsScreen)
        {
            _inventoryScreen = inventoryScreen;
            _settingsScreen = settingsScreen;
            _settingsButton.onClick.AddListener(SettingsButtonClickedEventHandler);
            _inventoryButton.onClick.AddListener(InventoryButtonClickedEventHandler);
        }

        private void SettingsButtonClickedEventHandler()
        {
            _settingsScreen.Open();
        }

        private void InventoryButtonClickedEventHandler()
        {
            _inventoryScreen.Open();
        }
    }
}