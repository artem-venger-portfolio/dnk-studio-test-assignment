using UnityEngine;

namespace ResourceLooter
{
    public class PlayerPrefsSaveManager : ISaveManager
    {
        private const string KEY = "SaveData";
        private SaveData _saveData;

        public bool IsMusicOn
        {
            get => _saveData.IsMusicOn;
            set => _saveData.IsMusicOn = value;
        }

        public void Load()
        {
            var saveDataJson = PlayerPrefs.GetString(KEY);
            _saveData = saveDataJson == string.Empty
                    ? new SaveData()
                    : JsonUtility.FromJson<SaveData>(saveDataJson);
        }

        public void Save()
        {
            var saveDataJson = JsonUtility.ToJson(_saveData);
            PlayerPrefs.SetString(KEY, saveDataJson);
        }
    }
}