namespace ResourceLooter
{
    public class Player
    {
        private readonly PlayerMover _playerMover;
        private readonly PlayerAnimationSwitcher _animationSwitcher;

        public Player(PlayerMover playerMover, PlayerAnimationSwitcher animationSwitcher)
        {
            _playerMover = playerMover;
            _animationSwitcher = animationSwitcher;
        }

        public void Enable()
        {
            _playerMover.Enable();
            _animationSwitcher.Enable();
        }

        public void Disable()
        {
            _playerMover.Disable();
            _animationSwitcher.Disable();
        }
    }
}