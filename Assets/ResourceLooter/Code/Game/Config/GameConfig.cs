using System;

namespace ResourceLooter
{
    [Serializable]
    public class GameConfig
    {
        public float DragThreshold;
        public CameraConfig CameraConfig;
        public PlayerConfig PlayerConfig;
    }
}