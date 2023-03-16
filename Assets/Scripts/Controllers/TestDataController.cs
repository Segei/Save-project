using Assets.Scripts.Models;
using TMPro;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Controllers
{
    public class TestDataController : MonoBehaviour
    {
        [Inject] private readonly DataContainer data;

        [SerializeField] private TMP_InputField intValue;
        [SerializeField] private TMP_InputField stringValue;
        [SerializeField] private TMP_InputField floatValue;

        private void Start()
        {
            intValue.onEndEdit.AddListener(e => data.TestSaveData.IntValue = int.Parse(e));
            stringValue.onEndEdit.AddListener(e => data.TestSaveData.StringValue = e);
            floatValue.onEndEdit.AddListener(e => data.TestSaveData.FloatValue = float.Parse(e));
        }

        public void Load()
        {
            intValue.SetTextWithoutNotify(data.TestSaveData.IntValue.ToString());
            stringValue.SetTextWithoutNotify(data.TestSaveData.StringValue.ToString());
            floatValue.SetTextWithoutNotify(data.TestSaveData.FloatValue.ToString());
        }
    }
}
