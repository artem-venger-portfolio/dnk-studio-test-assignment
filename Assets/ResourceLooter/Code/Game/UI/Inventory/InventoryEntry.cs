using TMPro;
using UnityEngine;

namespace ResourceLooter
{
    public class InventoryEntry : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text _nameField;

        [SerializeField]
        private TMP_Text _countField;

        private ResourceType _resource;
        private int _count;

        public ResourceType Resource
        {
            get => _resource;
            set
            {
                _resource = value;
                _nameField.text = _resource.ToString();
            }
        }

        public void SetCount(int value)
        {
            _count = value;
            _countField.name = _count.ToString();
        }
    }
}