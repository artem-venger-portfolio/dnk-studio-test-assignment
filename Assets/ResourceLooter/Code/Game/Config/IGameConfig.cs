namespace ResourceLooter
{
    public interface IGameConfig
    {
        float DragThreshold { get; }
        CameraConfig CameraConfig { get; }
        PlayerConfig PlayerConfig { get; }
    }
}