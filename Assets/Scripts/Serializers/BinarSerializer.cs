using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using Assets.Scripts.Surrogates;
using Scripts.Interfaces;
using UnityEngine;

namespace Assets.Scripts.Serializers
{
    internal class BinarSerializer : ISerializer
    {
        public string FileExtension { get; } = ".dat";
        private BinaryFormatter formatter;
        private MemoryStream stream;
        public T Deserialize<T>(string data) where T : new()
        {
            Initialize(Convert.FromBase64String(data));
            T result = (T)formatter.Deserialize(stream) ?? new T();
            stream.Close();
            return result;
        }

        public string Serialize<T>(T data)
        {
            if (!data.GetType().IsSerializable)
            {
                return null;
            }
            Initialize();

            formatter.Serialize(stream, data);
            string result = Convert.ToBase64String(stream.ToArray());
            stream.Close();
            return result;
        }

        private void Initialize(byte[] bytes = null)
        {
            formatter ??= new BinaryFormatter();
            stream = bytes == null ? new() : new(bytes);
            SurrogateSelector surrogate = new();
            surrogate.AddSurrogate(typeof(Vector3), new StreamingContext(StreamingContextStates.All), new Vector3Serializer());
            surrogate.AddSurrogate(typeof(Quaternion), new StreamingContext(StreamingContextStates.All), new QuaternionSerializer());
            formatter.SurrogateSelector = surrogate;
        }

    }
}
