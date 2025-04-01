﻿using UnityEngine;

namespace ResourceLooter
{
    public abstract class BuildingBase : MonoBehaviour
    {
        public abstract void Initialize(IGameConfig config);
    }
}