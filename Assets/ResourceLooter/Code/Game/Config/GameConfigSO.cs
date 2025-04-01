using UnityEngine;

namespace ResourceLooter
{
    [CreateAssetMenu(fileName = TYPE_NAME, menuName = CreateMenuConstants.MENU_NAME + "/" + TYPE_NAME)]
    public class GameConfigSO : ScriptableObject, IGameConfig
    {
        [SerializeField]
        private GameConfig _config;

        private const string TYPE_NAME = nameof(GameConfigSO);

        public float PlayerSpeed => _config.PlayerSpeed;

        public float DragThreshold => _config.DragThreshold;

        public CameraConfig CameraConfig => _config.CameraConfig;
    }
}