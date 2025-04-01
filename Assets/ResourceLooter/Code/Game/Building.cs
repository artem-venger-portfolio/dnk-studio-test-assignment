﻿using UnityEngine;

namespace ResourceLooter
{
    public class Building : MonoBehaviour
    {
        [SerializeField]
        private ResourceType _produce;

        private int _resourcesCount;
        private IGameConfig _config;
        private float _elapsedTime;

        public void Initialize(IGameConfig config)
        {
            _config = config;
        }

        private void Update()
        {
            _elapsedTime = Time.deltaTime;
            if (_elapsedTime >= _config.ProductionTime)
            {
                _elapsedTime -= _config.ProductionTime;
                _resourcesCount++;
            }
        }
    }
}