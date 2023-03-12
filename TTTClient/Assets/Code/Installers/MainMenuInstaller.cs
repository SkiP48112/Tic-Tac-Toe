using Code.Logic;
using Code.Logic.Contracts;
using Code.Views;
using UnityEngine;
using Zenject;

namespace Code.Installers
{
    public class MainMenuInstaller : MonoInstaller<MainMenuInstaller>
    {
        [SerializeField] private MainMenuView _view;
        
        public override void InstallBindings()
        {
            Container.Bind<MainMenuView>().FromInstance(_view);
            Container.Bind<IMainMenuController>().To<MainMenuController>().AsSingle().NonLazy();
        }
    }
}