using System;

namespace ResourceLooter
{
    [Serializable]
    public class GameConfig
    {
        public float ProductionTime;
        public float DragThreshold;
        public CameraConfig CameraConfig;
        public PlayerConfig PlayerConfig;
    }
}