using UnityEngine;
using UnityEngine.UI;

namespace ResourceLooter
{
    public class SettingsScreen : ScreenBase
    {
        [SerializeField]
        private Button _closeButton;
        
        [SerializeField]
        private Toggle _music;

        public void Initialize()
        {
            _music.onValueChanged.AddListener(MusicValueChangedEventHandler);
            _closeButton.onClick.AddListener(Close);
        }

        private void MusicValueChangedEventHandler(bool isOn)
        {
            Debug.Log($"{nameof(MusicValueChangedEventHandler)} {isOn}");
        }
    }
}