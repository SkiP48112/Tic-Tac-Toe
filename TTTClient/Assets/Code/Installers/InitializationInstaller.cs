using Code.Logic;
using Code.Logic.Contracts;
using Code.Views;
using UnityEngine;
using Zenject;

namespace Code.Installers
{
    public class InitializationInstaller : MonoInstaller<InitializationInstaller>
    {
        [SerializeField] private InitializationView _view;
        
        public override void InstallBindings()
        {
            Container.Bind<InitializationView>().FromInstance(_view);
            Container.Bind<IInitializationController>().To<InitializationController>().AsSingle().NonLazy();
        }
    }
}