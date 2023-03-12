using Code.Logic;
using Code.Logic.Contracts;
using Code.Views;
using UnityEngine;
using Zenject;

namespace Code.Installers
{
    public class SceneLoaderInstaller : MonoInstaller<SceneLoaderInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<ISceneLoader>().To<SceneLoader>().AsSingle();
        }
    }
}