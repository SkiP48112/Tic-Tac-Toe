using Code.Types;

namespace Code.Logic
{
    public class GameDataController
    {
        private GameData _data;

        public void SetFieldSize(int size)
        {
            _data.FieldSize = size;
        }

        public void SetGameMode(GameMode gameMode)
        {
            _data.Mode = gameMode;
        }

        public void SetWinner(CellState cellState)
        {
            _data.Winner = cellState;
        }

        public GameData GetGameData()
        {
            return _data;
        }
    }
}