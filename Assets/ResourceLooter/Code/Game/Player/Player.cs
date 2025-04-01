namespace ResourceLooter
{
    public class Player
    {
        private readonly PlayerMover _playerMover;
        private readonly PlayerAnimationSwitcher _animationSwitcher;
        private readonly ResourceExtractor _resourceExtractor;

        public Player(PlayerMover playerMover, PlayerAnimationSwitcher animationSwitcher,
                      ResourceExtractor resourceExtractor)
        {
            _playerMover = playerMover;
            _animationSwitcher = animationSwitcher;
            _resourceExtractor = resourceExtractor;
        }

        public void Enable()
        {
            _playerMover.Enable();
            _animationSwitcher.Enable();
            _resourceExtractor.Enable();
        }

        public void Disable()
        {
            _playerMover.Disable();
            _animationSwitcher.Disable();
            _resourceExtractor.Disable();
        }
    }
}