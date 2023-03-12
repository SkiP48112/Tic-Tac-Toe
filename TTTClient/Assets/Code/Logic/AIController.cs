using System;
using System.Collections.Generic;
using System.Linq;
using Code.Logic.Contracts;
using Code.Types;
using Code.Views;
using ModestTree;

namespace Code.Logic
{
    public class AIController : IAIController
    {
        private Dictionary<int, CellView> _cells = new();
        private int _size;

        public void UpdateFieldSize()
        {
            _size = Convert.ToInt32(Math.Sqrt(_cells.Count));
        }

        public void UpdateGameField(Dictionary<int, CellView> cells)
        {
            _cells = cells;
        }
        
        public int Turn(CellState value)
        {
            var rows = CollectRows();
            var columns = CollectColumns();
            var diagonals = CollectDiagonals();
            var gamePositions = rows.Concat(columns).Concat(diagonals).ToList();
            
            var canWinValue = CanWin(gamePositions, value);
            if (canWinValue != -1)
            {
                return canWinValue;
            }

            var canLooseValue = CanWin(gamePositions, value.ToggleState());
            if (canLooseValue != -1)
            {
                return canLooseValue;
            }

            return GetBestTurn(gamePositions, value);
        }

        private int GetBestTurn(List<GamePosition> gamePositions, CellState value)
        {
            var result = new List<int>();
            var min = _size;

            foreach (var gamePosition in gamePositions)
            {
                var badValues = GetAmountOfValues(gamePosition.Values, value.ToggleState());
                if (badValues != 0)
                {
                    continue;
                }

                var emptyValues = GetAmountOfValues(gamePosition.Values, CellState.Empty);
                if (emptyValues <= min && emptyValues > 0)
                {
                    if (emptyValues == min && !result.IsEmpty())
                    {
                        result.Add(gamePosition.First(x => x.Value.GetValue() == CellState.Empty).Key);
                        continue;
                    }
                    min = emptyValues;
                    result.Clear();
                    result.Add(gamePosition.First(x => x.Value.GetValue() == CellState.Empty).Key);
                }
            }


            if (!result.IsEmpty())
            {
                var r = new Random();
                return result[r.Next(0, result.Count - 1)];
            }

            return GetRandomTurn(gamePositions);
        }

        private int GetRandomTurn(List<GamePosition> gamePositions)
        {
            foreach (var gamePosition in gamePositions)
            {
                var emptyValues = GetAmountOfValues(gamePosition.Values, CellState.Empty);
                if (emptyValues > 0)
                {
                    return gamePosition.First(x => x.Value.GetValue() == CellState.Empty).Key;
                }
            }

            return -1;
        }

        private int CanWin(List<GamePosition> gamePositions, CellState value)
        {
            foreach (var gamePosition in gamePositions)
            {
                var goodValues = GetAmountOfValues(gamePosition.Values, value);
                var emptyValues = GetAmountOfValues(gamePosition.Values, CellState.Empty);
                if (emptyValues == 1 && goodValues == _size - 1)
                {
                    return gamePosition.First(x => x.Value.GetValue() == CellState.Empty).Key;
                }
            }

            return -1;
        }

        private int GetAmountOfValues(Dictionary<int, CellView>.ValueCollection cells, CellState value)
        {
            return cells.Count(cell => cell.GetValue() == value);
        }

        private List<GamePosition> CollectRows()
        {
            var result = new List<GamePosition>();
            for (var i = 0; i < _size; i++)
            {
                var gamePosition = new GamePosition();
                var leftBorder = i * _size;
                var rightBorder = leftBorder + _size - 1;
                
                for (var j = leftBorder; j <= rightBorder; j++)
                {
                    gamePosition.Add(j, _cells[j]);
                }

                result.Add(gamePosition);
            }
            
            return result;
        }

        private List<GamePosition> CollectColumns()
        {
            var result = new List<GamePosition>();
            for (var i = 0; i < _size; i++)
            {
                var gamePosition = new GamePosition();
                var upperBorder = i;
                var lowerBorder = i + _size * (_size - 1);
                
                for (var j = upperBorder; j <= lowerBorder; j += _size)
                {
                    gamePosition.Add(j, _cells[j]);
                }
                
                result.Add(gamePosition);
            }

            return result;
        }

        private List<GamePosition> CollectDiagonals()
        {
            var result = new List<GamePosition>();

            var counter = 0;
            var gamePosition = new GamePosition();
            for (var i = 0; i < _size; i++)
            {
                var index = i * _size + counter;
                gamePosition.Add(index, _cells[index]);
                counter++;
            }
            result.Add(gamePosition);
            gamePosition.Clear();
            
            counter = _size - 1;
            for (int i = 0; i < _size; i++)
            {
                var index = i * _size + counter;
                gamePosition.Add(index, _cells[index]);

                counter--;
            }
            result.Add(gamePosition);

            return result;
        }
    }
}