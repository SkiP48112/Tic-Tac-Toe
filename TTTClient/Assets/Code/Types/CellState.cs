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
                _ => ""
            };
        }

        public static CellState ConvertTo(this string value)
        {
            return value switch
            {
                "" => CellState.Empty,
                "X" => CellState.Cross ,
                "O" => CellState.Zero,
                _ => CellState.Empty
            };
        }

        public static CellState ToggleState(this CellState state)
        {
            return state switch
            {
                CellState.Empty => CellState.Empty,
                CellState.Cross => CellState.Zero,
                CellState.Zero => CellState.Cross,
                _ => CellState.Empty
            };
        }
    }
}