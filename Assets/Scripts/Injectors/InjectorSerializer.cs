using Assets.Scripts.Serializers;
using Scripts.Interfaces;
using Scripts.Serializers;
using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "InjectorSerializer", menuName = "Installers/InjectorSerializer")]
public class InjectorSerializer : ScriptableObjectInstaller<InjectorSerializer>
{
    [SerializeField] private Serializer serializers;
    private ISerializer serializer;


    public override void InstallBindings()
    {
        serializer = Instance();
        _ = Container.Bind<ISerializer>().FromInstance(serializer).AsSingle().NonLazy();
    }

    private ISerializer Instance()
    {
        return serializers switch
        {
            Serializer.JSON => new JSONSerializer(),
            Serializer.BINARY => new BinarSerializer(),
            _ => null,
        };
    }

    [System.Serializable]
    public enum Serializer
    {
        JSON,
        BINARY,
    }
}