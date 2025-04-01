using System;
using UnityEngine;

namespace ResourceLooter
{
    [Serializable]
    public class CameraConfig
    {
        [SerializeField]
        private float _followTime;

        [SerializeField]
        private float _decelerationTime;

        public float FollowTime => _followTime;

        public float DecelerationTime => _decelerationTime;
    }
}