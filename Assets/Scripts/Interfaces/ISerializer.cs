namespace Scripts.Interfaces
{
    public interface ISerializer
    {
        string FileExtension { get; }

        string Serialize<T>(T data);
        T Deserialize<T>(string data) where T : new();
    }
}
