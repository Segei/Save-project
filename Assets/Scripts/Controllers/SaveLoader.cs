using Assets.Scripts.Models;
using Scripts.Interfaces;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

namespace Assets.Scripts
{
    public class SaveLoader : MonoBehaviour
    {
        [Inject] private DataContainer testSaveData;
        [Inject] private IProviderSave provider;
        public UnityEvent LoadData;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.F5))
            {
                foreach(var data in testSaveData.GetType().GetProperties())
                {
                    provider.Save(data.PropertyType.ToString(), data.GetValue(testSaveData));
                }
            }
            if (Input.GetKeyDown(KeyCode.F6))
            {
                foreach (var data in testSaveData.GetType().GetProperties())
                {
                    data.SetValue(testSaveData, provider.Load<object>(data.PropertyType.ToString()));
                }
                LoadData?.Invoke();
            }
        }

    }
}
