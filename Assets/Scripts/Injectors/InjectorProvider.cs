using Scripts.Interfaces;
using Scripts.Providers;
using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "InjectorProvider", menuName = "Installers/InjectorProvider")]
public class InjectorProvider : ScriptableObjectInstaller<InjectorProvider>
{
    [SerializeField] private Providers providers;
    private IProviderSave provider;
    [Inject] private readonly ISerializer serializer;
    public override void InstallBindings()
    {
        provider = Instance();
        _ = Container.Bind<IProviderSave>().FromInstance(provider).AsSingle().NonLazy();
    }

    private IProviderSave Instance()
    {
        return providers switch
        {
            Providers.File => new FileProvider(serializer),
            Providers.PlayerPrefs => new PlayerPrefsProviderd(serializer),
            _ => null,
        };
    }

    [System.Serializable]
    public enum Providers
    {
        File,
        PlayerPrefs,
    }
}