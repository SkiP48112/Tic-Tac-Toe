using Code.Logic.Contracts;
using Code.Views;

namespace Code.Logic
{
    public class GameOverController : IGameOverController
    {
        private readonly ISceneLoader _sceneLoader;

        public GameOverController(GameOverView view, GameDataController gameDataController, ISceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
            view.Bind(gameDataController.GetGameData());
            view.OnClick += OnClick;
        }

        private void OnClick()
        {
            _sceneLoader.LoadScene("SC_Initialize");
        }
    }
}