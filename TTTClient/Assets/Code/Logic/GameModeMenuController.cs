using Code.Logic.Contracts;
using Code.Types;
using Code.Views;
using Zenject;

namespace Code.Logic
{
    public class GameModeMenuController : IGameModeMenuController
    {
        private readonly GameModeMenuView _view;
        private readonly ISceneLoader _sceneLoader;
        private readonly GameDataController _dataController;

        [Inject]
        public GameModeMenuController(GameModeMenuView view, ISceneLoader sceneLoader,
            GameDataController dataController)
        {
            _view = view;
            _sceneLoader = sceneLoader;
            _dataController = dataController;

            Bind();
        }

        private void Bind()
        {
            _view.OnSelected += OnSelected;
        }

        private void OnSelected(GameMode gameMode)
        {
            _sceneLoader.LoadScene($"SC_Game");
            _dataController.SetGameMode(gameMode);
        }
    }
}