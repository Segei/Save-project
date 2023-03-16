namespace Scripts.Interfaces
{
    public interface IProviderSave
    {
        void Save<T>(string name, T data);
        T Load<T>(string name) where T : new();
    }
}