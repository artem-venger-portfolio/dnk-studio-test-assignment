using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ResourceLooter
{
    public class ResourceExtractor
    {
        private readonly PlayerView _playerView;
        private readonly ICoroutineController _coroutineController;
        private readonly List<BuildingBase> _interactingBuildings;
        private Coroutine _resourceExtractionCoroutine;

        public ResourceExtractor(PlayerView playerView, ICoroutineController coroutineController)
        {
            _playerView = playerView;
            _coroutineController = coroutineController;
            _interactingBuildings = new List<BuildingBase>(capacity: 4);
        }

        public void Enable()
        {
            _playerView.BuildingInteractionZoneEntered += BuildingInteractionZoneEnteredEventHandler;
            _playerView.BuildingInteractionZoneExited += BuildingInteractionZoneExitedEventHandler;
            _resourceExtractionCoroutine = _coroutineController.Run(GetResourceExtractionCoroutine());
        }

        public void Disable()
        {
            _playerView.BuildingInteractionZoneEntered -= BuildingInteractionZoneEnteredEventHandler;
            _playerView.BuildingInteractionZoneExited -= BuildingInteractionZoneExitedEventHandler;
            _interactingBuildings.Clear();
            _coroutineController.Stop(_resourceExtractionCoroutine);
            _resourceExtractionCoroutine = null;
        }

        private void BuildingInteractionZoneEnteredEventHandler(BuildingBase building)
        {
            _interactingBuildings.Add(building);
        }

        private void BuildingInteractionZoneExitedEventHandler(BuildingBase building)
        {
            _interactingBuildings.Remove(building);
        }

        private IEnumerator GetResourceExtractionCoroutine()
        {
            while (true)
            {
                foreach (var currentBuilding in _interactingBuildings)
                {
                }

                yield return new WaitForSeconds(seconds: 0.2f);
            }
        }
    }
}