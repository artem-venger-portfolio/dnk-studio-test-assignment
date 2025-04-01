using System;

namespace ResourceLooter
{
    [Serializable]
    public class GameConfig
    {
        public float PlayerSpeed;
        public float DragThreshold;
        public CameraConfig CameraConfig;
    }
}