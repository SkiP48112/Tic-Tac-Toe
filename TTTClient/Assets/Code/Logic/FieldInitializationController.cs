using Code.Logic.Contracts;
using Code.Types;
using Code.Views;

namespace Code.Logic
{
    public class FieldInitializationController : IFieldInitializationController
    {
        private readonly FieldInitializationView _view;
        private readonly RuntimeView _runtime;
        private readonly IGameManager _gameManager;

        public FieldInitializationController(GameDataController gameDataController, FieldInitializationView view, RuntimeView runtime, IGameManager gameManager)
        {
            _view = view;
            _runtime = runtime;
            _gameManager = gameManager;
            InitializeField(gameDataController.GetGameData());
        }

        private void InitializeField(GameData gameData)
        {
            _view.Bind(gameData.FieldSize);
            _view.SpawnCells(gameData);

            _runtime.CollectCells();
            _runtime.BindGameMode(gameData.Mode);
            _runtime.Bind(_gameManager);
        }
    }
}