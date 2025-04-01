namespace ResourceLooter
{
    public class ResourceExtractor
    {
        private readonly PlayerView _playerView;

        public ResourceExtractor(PlayerView playerView)
        {
            _playerView = playerView;
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
        }

        private void BuildingInteractionZoneEnteredEventHandler(BuildingBase building)
        {
        }

        private void BuildingInteractionZoneExitedEventHandler(BuildingBase building)
        {
        }
    }
}