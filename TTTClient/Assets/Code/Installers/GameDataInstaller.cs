using Code.Logic;
using Zenject;

namespace Code.Installers
{
    public class GameDataInstaller : MonoInstaller<GameDataInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<GameDataController>().AsSingle().NonLazy();
        }
    }
}