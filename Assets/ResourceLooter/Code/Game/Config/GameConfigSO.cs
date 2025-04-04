﻿using UnityEngine;

namespace ResourceLooter
{
    [CreateAssetMenu(fileName = TYPE_NAME, menuName = CreateMenuConstants.MENU_NAME + "/" + TYPE_NAME)]
    public class GameConfigSO : ScriptableObject, IGameConfig
    {
        [SerializeField]
        private GameConfig _config;

        private const string TYPE_NAME = nameof(GameConfigSO);

        public float ProductionTime => _config.ProductionTime;

        public float DragThreshold => _config.DragThreshold;

        public CameraConfig CameraConfig => _config.CameraConfig;

        public PlayerConfig PlayerConfig => _config.PlayerConfig;
    }
}