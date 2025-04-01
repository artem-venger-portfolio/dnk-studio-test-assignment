using UnityEngine;

namespace ResourceLooter
{
    public class Player
    {
        private readonly PlayerMover _playerMover;
        private readonly Animator _animator;

        public Player(PlayerMover playerMover, Animator animator)
        {
            _playerMover = playerMover;
            _animator = animator;
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