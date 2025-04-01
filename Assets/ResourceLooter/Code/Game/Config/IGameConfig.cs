namespace ResourceLooter
{
    public interface IGameConfig
    {
        float ProductionTime { get; }
        float DragThreshold { get; }
        CameraConfig CameraConfig { get; }
        PlayerConfig PlayerConfig { get; }
    }
}