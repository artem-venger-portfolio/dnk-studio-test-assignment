namespace ResourceLooter
{
    public interface ISaveManager
    {
        void Load();
        void Save();
        void SetInMusicOn(bool value);
    }
}