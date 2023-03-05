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

        public GameData GetGameData()
        {
            return _data;
        }
    }
}