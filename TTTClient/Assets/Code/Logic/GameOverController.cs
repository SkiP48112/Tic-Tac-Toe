using Code.Logic.Contracts;
using Code.Views;

namespace Code.Logic
{
    public class GameOverController : IGameOverController
    {
        public GameOverController(GameOverView view, GameDataController gameDataController)
        {
            view.Bind(gameDataController.GetGameData());
        }
    }
}