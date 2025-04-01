namespace ResourceLooter
{
    public interface ISaveManager
    {
        bool IsMusicOn { get; set; }
        void Load();
        void Save();
    }
}