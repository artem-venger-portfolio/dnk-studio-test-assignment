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

        public void Initialize(InventoryScreen inventoryScreen)
        {
            _inventoryScreen = inventoryScreen;
            _settingsButton.onClick.AddListener(SettingsButtonClickedEventHandler);
            _inventoryButton.onClick.AddListener(InventoryButtonClickedEventHandler);
        }

        private void SettingsButtonClickedEventHandler()
        {
        }

        private void InventoryButtonClickedEventHandler()
        {
            _inventoryScreen.Open();
        }
    }
}