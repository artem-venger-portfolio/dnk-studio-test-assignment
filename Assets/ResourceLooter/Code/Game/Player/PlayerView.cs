using UnityEngine;

namespace ResourceLooter
{
    public class PlayerView : MonoBehaviour
    {
        [SerializeField]
        private CharacterController _characterController;

        [SerializeField]
        private Animator _animator;

        public CharacterController CharacterController => _characterController;

        public Animator Animator => _animator;
    }
}