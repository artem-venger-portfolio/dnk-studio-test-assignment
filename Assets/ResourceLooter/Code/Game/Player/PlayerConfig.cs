using System;
using UnityEngine;

namespace ResourceLooter
{
    [Serializable]
    public class PlayerConfig
    {
        [SerializeField]
        private float _moveSpeed;

        [SerializeField]
        private float _rotationSpeed;

        public float MoveSpeed => _moveSpeed;

        public float RotationSpeed => _rotationSpeed;
    }
}