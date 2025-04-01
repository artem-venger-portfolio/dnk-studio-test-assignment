using UnityEngine;

namespace ResourceLooter
{
    public class PlayerPrefsSaveManager : ISaveManager
    {
        private const string KEY = "SaveData";
        private SaveData _saveData;

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

        public void SetInMusicOn(bool value)
        {
            _saveData.IsMusicOn = value;
        }
    }
}