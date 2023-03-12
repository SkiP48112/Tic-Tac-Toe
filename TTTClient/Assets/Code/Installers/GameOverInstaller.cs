using Code.Logic;
using Code.Logic.Contracts;
using Code.Views;
using UnityEngine;
using Zenject;

namespace Code.Installers
{
    public class GameOverInstaller : MonoInstaller<GameOverInstaller>
    {
        [SerializeField] private GameOverView _view;
        
        public override void InstallBindings()
        {
            Container.Bind<GameOverView>().FromInstance(_view);
            Container.Bind<IGameOverController>().To<GameOverController>().AsSingle().NonLazy();
        }
    }
}