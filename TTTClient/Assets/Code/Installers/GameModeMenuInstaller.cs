using Code.Logic;
using Code.Views;
using UnityEngine;
using Zenject;

namespace Code.Installers
{
    public class GameModeMenuInstaller : MonoInstaller<GameModeMenuInstaller>
    {
        [SerializeField] private GameModeMenuView _view;
        
        public override void InstallBindings()
        {
            Container.Bind<GameModeMenuView>().FromInstance(_view);
            Container.Bind<IGameModeMenuController>().To<GameModeMenuController>().AsSingle().NonLazy();
        }
    }
}