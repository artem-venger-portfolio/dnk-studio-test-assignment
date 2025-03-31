namespace ResourceLooter
{
    public class Player
    {
        private readonly PlayerMover _playerMover;

        public Player(PlayerMover playerMover)
        {
            _playerMover = playerMover;
        }

        public void Enable()
        {
            _playerMover.Enable();
        }

        public void Disable()
        {
            _playerMover.Disable();
        }
    }
}