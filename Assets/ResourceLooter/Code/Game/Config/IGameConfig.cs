namespace ResourceLooter
{
    public interface IGameConfig
    {
        public float PlayerSpeed { get; }
        float DragThreshold { get; }
        CameraConfig CameraConfig { get; }
    }
}