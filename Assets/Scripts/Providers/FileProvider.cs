using System;
using System.IO;
using Scripts.Interfaces;
using UnityEngine;

namespace Scripts.Providers
{
    public class FileProvider : IProviderSave
    {
        private string filePath;
        private readonly ISerializer serializer;


        public FileProvider(ISerializer value)
        {
            serializer = value;
        }

        public T Load<T>(string name) where T : new()
        {
            Initialize(name);
            return serializer.Deserialize<T>(File.ReadAllText(filePath));
        }

        public void Save<T>(string name, T data)
        {
            Initialize(name);
            File.WriteAllText(filePath, serializer.Serialize(data));
        }


        private void Initialize(string name)
        {
            string directory = Application.streamingAssetsPath + "/";
            filePath = directory + name + serializer.FileExtension;
            if (!Directory.Exists(directory))
            {
                _ = Directory.CreateDirectory(directory);
            }
            if (!File.Exists(filePath))
            {
                File.Create(filePath).Close();
            }
        }
    }
}
