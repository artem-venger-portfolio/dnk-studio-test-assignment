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

        private ISaveManager _saveManager;

        public void Initialize(ISaveManager saveManager)
        {
            _saveManager = saveManager;
            _music.isOn = _saveManager.IsMusicOn;
            _music.onValueChanged.AddListener(MusicValueChangedEventHandler);
            _closeButton.onClick.AddListener(Close);
        }

        private void MusicValueChangedEventHandler(bool isOn)
        {
            _saveManager.IsMusicOn = isOn;
        }
    }
}