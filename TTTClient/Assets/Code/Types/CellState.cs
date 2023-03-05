using System;

namespace Code.Types
{
    public enum CellState
    {
        Empty,
        Cross,
        Zero
    }

    public static class CellStatesExtension
    {
        public static string ConvertTo(this CellState state)
        {
            return state switch
            {
                CellState.Empty => "",
                CellState.Cross => "X",
                CellState.Zero => "O",
                _ => throw new ArgumentOutOfRangeException(nameof(state), state, null)
            };
        }
    }
}