using System.Runtime.InteropServices;
using Newtonsoft.Json;
using Scripts.Interfaces;

namespace Scripts.Serializers
{
    internal class JSONSerializer : ISerializer
    {
        public string FileExtension { get; } = ".json";

        public T Deserialize<T>(string data) where T : new()
        {
            return JsonConvert.DeserializeObject<T>(data) ?? new T();
        }

        public string Serialize<T>(T data)
        {
            return JsonConvert.SerializeObject(data);
        }

    }
}
