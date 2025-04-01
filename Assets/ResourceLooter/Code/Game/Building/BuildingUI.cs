using TMPro;
using UnityEngine;

namespace ResourceLooter
{
    public class BuildingUI : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text _nameField;

        [SerializeField]
        private TMP_Text _countField;

        public void SetName(ResourceType resource)
        {
            _nameField.text = resource.ToString();
        }

        public void SetCount(int count)
        {
            _countField.text = count.ToString();
        }
    }
}