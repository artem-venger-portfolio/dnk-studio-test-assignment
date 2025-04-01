using System;
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

        public event Action<BuildingBase> BuildingInteractionZoneEntered;

        public event Action<BuildingBase> BuildingInteractionZoneExited;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent<BuildingBase>(out var building))
            {
                BuildingInteractionZoneEntered?.Invoke(building);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.TryGetComponent<BuildingBase>(out var building))
            {
                BuildingInteractionZoneExited?.Invoke(building);
            }
        }
    }
}