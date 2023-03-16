using System;
using UnityEngine;


namespace Assets.Scripts.Models
{
    [Serializable]
    public class DataContainer
    {
        [field: SerializeField]public TestSaveData TestSaveData { get; set; }
    }
}
