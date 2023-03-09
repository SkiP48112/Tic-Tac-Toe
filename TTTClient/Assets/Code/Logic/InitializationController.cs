using Code.Logic.Contracts;
using Code.Views;

namespace Code.Logic
{
    public class InitializationController : IInitializationController
    {
        private readonly ISceneLoader _sceneLoader;

        public InitializationController(InitializationView view, ISceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
            view.OnInitialized += Initialize;
        }

        private void Initialize()
        {
            _sceneLoader.LoadScene("SC_MainMenu");
        }
    }
}