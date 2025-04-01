using System.Collections.Generic;

namespace ResourceLooter
{
    public class ResourceExtractor
    {
        private readonly PlayerView _playerView;
        private readonly List<BuildingBase> _interactingBuildings;

        public ResourceExtractor(PlayerView playerView)
        {
            _playerView = playerView;
            _interactingBuildings = new List<BuildingBase>(capacity: 4);
        }

        public void Enable()
        {
            _playerView.BuildingInteractionZoneEntered += BuildingInteractionZoneEnteredEventHandler;
            _playerView.BuildingInteractionZoneExited += BuildingInteractionZoneExitedEventHandler;
        }

        public void Disable()
        {
            _playerView.BuildingInteractionZoneEntered -= BuildingInteractionZoneEnteredEventHandler;
            _playerView.BuildingInteractionZoneExited -= BuildingInteractionZoneExitedEventHandler;
            _interactingBuildings.Clear();
        }

        private void BuildingInteractionZoneEnteredEventHandler(BuildingBase building)
        {
            _interactingBuildings.Add(building);
        }

        private void BuildingInteractionZoneExitedEventHandler(BuildingBase building)
        {
            _interactingBuildings.Remove(building);
        }
    }
}