namespace System
{
    public interface ICloseWatcher
    {
        event Action Closing;
    }
}