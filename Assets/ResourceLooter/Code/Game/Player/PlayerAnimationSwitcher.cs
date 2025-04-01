using UnityEngine;

namespace ResourceLooter
{
    public class PlayerAnimationSwitcher
    {
        private readonly PlayerMover _playerMover;
        private readonly Animator _animator;

        public PlayerAnimationSwitcher(PlayerMover playerMover, Animator animator)
        {
            _playerMover = playerMover;
            _animator = animator;
        }

        public void Enable()
        {
            _playerMover.MovementStarted += MovementStartedEventHandler;
            _playerMover.MovementFinished += MovementFinishedEventHandler;
        }

        public void Disable()
        {
            _playerMover.MovementStarted -= MovementStartedEventHandler;
            _playerMover.MovementFinished -= MovementFinishedEventHandler;
        }

        private void MovementStartedEventHandler()
        {
        }

        private void MovementFinishedEventHandler()
        {
        }
    }
}