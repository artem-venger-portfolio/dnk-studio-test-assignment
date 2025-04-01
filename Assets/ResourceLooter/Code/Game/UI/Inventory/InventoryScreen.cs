using System;
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

        private InventoryEntry[] _entries;
        private Inventory _inventory;

        public void Initialize(Inventory inventory)
        {
            _inventory = inventory;
            _closeButton.onClick.AddListener(CloseButtonClickedEventHandler);
            CreateEntryForEachResource();
        }

        private void CreateEntryForEachResource()
        {
            var resources = Enum.GetValues(typeof(ResourceType));
            _entries = new InventoryEntry[resources.Length];
            for (var i = 0; i < resources.Length; i++)
            {
                var currentEntry = Instantiate(_entryTemplate, _scrollContent);
                currentEntry.Resource = (ResourceType)resources.GetValue(i);
                _entries[i] = currentEntry;
            }
        }

        private void CloseButtonClickedEventHandler()
        {
            Close();
        }

        private void OnEnable()
        {
            foreach (var currentEntry in _entries)
            {
                var resource = currentEntry.Resource;
                var count = _inventory.Get(resource);
                currentEntry.SetCount(count);
            }
        }
    }
}