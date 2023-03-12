using System.Collections.Generic;
using Code.Types;
using Code.Views;

namespace Code.Logic.Contracts
{
    public interface IGameManager
    {
        int Turn(Dictionary<int, CellView> cells, CellState value);
        bool CheckForGameOver();
        void BindCells(Dictionary<int, CellView> cells);
        CellState GetCurrentState();
        void ToggleCurrentState();
    }
}