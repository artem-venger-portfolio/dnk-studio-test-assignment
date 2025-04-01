using UnityEngine;
using UnityEngine.UI;

namespace ResourceLooter
{
    public class InventoryScreen : ScreenBase
    {
        [SerializeField]
        private InventoryEntry _entryTemplate;

        [SerializeField]
        private Transform _scrollContent;

        [SerializeField]
        private Button _closeButton;

        private Inventory _inventory;

        public void Initialize(Inventory inventory)
        {
            _inventory = inventory;
        }
    }
}