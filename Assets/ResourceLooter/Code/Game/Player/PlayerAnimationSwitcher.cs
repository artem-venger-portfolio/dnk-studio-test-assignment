using UnityEngine;

namespace ResourceLooter
{
    public class PlayerAnimationSwitcher
    {
        private static readonly int _isRunning = Animator.StringToHash(name: "IsRunning");
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
            SetIsRunning(value: true);
        }

        private void MovementFinishedEventHandler()
        {
            SetIsRunning(value: false);
        }

        private void SetIsRunning(bool value)
        {
            _animator.SetBool(_isRunning, value);
        }
    }
}