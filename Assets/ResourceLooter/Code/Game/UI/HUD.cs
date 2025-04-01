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

        public void Initialize()
        {
            _settingsButton.onClick.AddListener(SettingsButtonClickedEventHandler);
            _inventoryButton.onClick.AddListener(InventoryButtonClickedEventHandler);
        }

        private void SettingsButtonClickedEventHandler()
        {
        }

        private void InventoryButtonClickedEventHandler()
        {
        }
    }
}