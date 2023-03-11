using Code.Logic;
using Code.Logic.Contracts;
using Code.Views;
using UnityEngine;
using Zenject;

namespace Code.Installers
{
    public class RuntimeInstaller : MonoInstaller<RuntimeInstaller>
    {
        [SerializeField] private RuntimeView _runtime;
        [SerializeField] private FieldInitializationView _view;
        
        public override void InstallBindings()
        {
            Container.Bind<RuntimeView>().FromInstance(_runtime);
            Container.Bind<FieldInitializationView>().FromInstance(_view);
            Container.Bind<IGameManager>().To<GameManager>().AsSingle().NonLazy();
            Container.Bind<IFieldInitializationController>().To<FieldInitializationController>().AsSingle().NonLazy();
        }
    }
}