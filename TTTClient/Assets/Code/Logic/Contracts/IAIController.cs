using System.Collections.Generic;
using Code.Types;
using Code.Views;

namespace Code.Logic.Contracts
{
    public interface IAIController
    {
        void UpdateFieldSize();
        void UpdateGameField(Dictionary<int, CellView> cells);
        int Turn(CellState value);
    }
}