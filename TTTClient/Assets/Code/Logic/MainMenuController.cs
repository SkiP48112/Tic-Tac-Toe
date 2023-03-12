using Code.Logic.Contracts;
using Code.Views;
using Zenject;

namespace Code.Logic
{
    public class MainMenuController : IMainMenuController
    {
        private readonly MainMenuView _view;
        private readonly ISceneLoader _sceneLoader;
        private readonly GameDataController _dataController;

        [Inject]
        public MainMenuController(MainMenuView view, ISceneLoader sceneLoader, GameDataController dataController)
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

        private void OnSelected(int data)
        {
            _sceneLoader.LoadScene($"SC_GameModeSelection");
            _dataController.SetFieldSize(data);
        }
    }
}