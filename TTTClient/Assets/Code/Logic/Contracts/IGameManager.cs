using System.Collections.Generic;
using Code.Types;
using Code.Views;

namespace Code.Logic.Contracts
{
    public interface IGameManager
    {
        void CheckForGameOver();
        void BindCells(Dictionary<int, CellView> cells);
        CellState GetCurrentState();
        void ToggleCurrentState();
    }
}