using Assets.Scripts.Models;
using UnityEngine;
using Zenject;

public class InjectorData : MonoInstaller
{
    [SerializeField] private DataContainer dataSave;

    public override void InstallBindings()
    {
        Container.Bind<DataContainer>().FromInstance(dataSave).AsSingle().NonLazy();
    }
}