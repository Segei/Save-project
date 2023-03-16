using System;
using Scripts.Interfaces;
using UnityEngine;

namespace Scripts.Providers
{
    public class PlayerPrefsProviderd : IProviderSave
    {
        private ISerializer serializer;

        public T Load<T>(string name) where T : new()
        {
            return serializer.Deserialize<T>(PlayerPrefs.GetString(name, null));
        }

        public void Save<T>(string name, T data)
        {
            PlayerPrefs.SetString(name, serializer.Serialize(data));
        }

        public PlayerPrefsProviderd(ISerializer value)
        {
            serializer = value;
        }
    }
}
