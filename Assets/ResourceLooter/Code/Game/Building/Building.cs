using UnityEngine;

namespace ResourceLooter
{
    public class Building : BuildingBase
    {
        [SerializeField]
        private ResourceType _produce;

        [SerializeField]
        private BuildingUI _ui;

        private int _resourcesCount;
        private IGameConfig _config;
        private float _elapsedTime;

        public override void Initialize(IGameConfig config)
        {
            _config = config;
            _ui.SetName(_produce);
            ResourcesCount = 0;
        }

        private int ResourcesCount
        {
            get => _resourcesCount;
            set
            {
                _resourcesCount = value;
                _ui.SetCount(_resourcesCount);
            }
        }

        private void Update()
        {
            _elapsedTime += Time.deltaTime;
            if (_elapsedTime >= _config.ProductionTime)
            {
                _elapsedTime -= _config.ProductionTime;
                ResourcesCount++;
            }
        }
    }
}