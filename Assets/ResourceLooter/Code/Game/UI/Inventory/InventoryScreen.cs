using UnityEngine;

namespace ResourceLooter
{
    public class InventoryScreen : ScreenBase
    {
        [SerializeField]
        private InventoryEntry _entryTemplate;

        private Inventory _inventory;

        public void Initialize(Inventory inventory)
        {
            _inventory = inventory;
        }
    }
}