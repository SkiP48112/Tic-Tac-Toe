using System;
using System.Collections.Generic;
using System.Linq;
using Code.Logic.Contracts;
using Code.Types;
using Code.Views;

namespace Code.Logic
{
    public class GameManager : IGameManager
    {
        private readonly GameDataController _gameDataController;
        private readonly ISceneLoader _sceneLoader;
        private CellState _currentState;
        private Dictionary<int, CellView> _cells;

        public GameManager(GameDataController gameDataController, ISceneLoader sceneLoader)
        {
            _gameDataController = gameDataController;
            _sceneLoader = sceneLoader;
            _currentState = CellState.Cross;
        }
        
        public void BindCells(Dictionary<int, CellView> cells)
        {
            _cells = cells;
        }

        public CellState GetCurrentState()
        {
            return _currentState;
        }

        public void ToggleCurrentState()
        {
            _currentState = _currentState.ToggleState();
        }

        public void CheckForGameOver()
        {
            var size = Convert.ToInt32(Math.Sqrt(_cells.Count));
            if (CheckRows(size) || CheckColumns(size) || CheckFirstDiagonal(size) || CheckSecondDiagonal(size))
            {
                _gameDataController.SetWinner(_currentState);
                _sceneLoader.LoadScene("SC_GameOver");
            }
            
            if (!CanMakeTurn())
            {
                _gameDataController.SetWinner(CellState.Empty);
                _sceneLoader.LoadScene("SC_GameOver");
            }
        }

        private bool CanMakeTurn()
        {
            return _cells.Values.Any(cell => cell.GetValue() == CellState.Empty);
        }

        private bool CheckRows(int size)
        {
            for (var i = 0; i < size; i++)
            {
                var leftBorder = i * size;
                var rightBorder = leftBorder + size - 1;
                var firstResultInRow = _cells[leftBorder].GetValue();
                if (firstResultInRow == CellState.Empty)
                {
                    continue;
                }
                
                var result = true;
                for (var j = leftBorder; j <= rightBorder; j++)
                {
                    if (!result)
                    {
                        continue;
                    }

                    result = firstResultInRow == _cells[j].GetValue();
                }

                if (result)
                {
                    return true;
                }
            }

            return false;
        }

        private bool CheckColumns(int size)
        {
            for (var i = 0; i < size; i++)
            {
                var upperBorder = i;
                var lowerBorder = i + size * (size - 1);
                var firstResultInRow = _cells[upperBorder].GetValue();
                if (firstResultInRow == CellState.Empty)
                {
                    continue;
                }
                
                var result = true;
                for (var j = upperBorder; j <= lowerBorder; j += size)
                {
                    if (!result)
                    {
                        continue;
                    }

                    result = firstResultInRow == _cells[j].GetValue();
                }
                
                if (result)
                {
                    return true;
                }
            }
            
            return false;
        }

        private bool CheckFirstDiagonal(int size)
        {
            var firstValue = _cells[0].GetValue();
            if (firstValue == CellState.Empty)
            {
                return false;
            }

            var counter = 1;
            for (var i = 1; i < size; i++)
            {
                var index = i * size + counter;
                if (_cells[index].GetValue() != firstValue)
                {
                    return false;
                }

                counter++;
            }
            
            return true;
        }
        
        private bool CheckSecondDiagonal(int size)
        {
            var firstValue = _cells[size - 1].GetValue();
            if (firstValue == CellState.Empty)
            {
                return false;
            }
            
            var counter = size - 2;
            for (int i = 1; i < size; i++)
            {
                var index = i * size + counter;
                if (_cells[index].GetValue() != firstValue)
                {
                    return false;
                }

                counter--;
            }
            
            return true;
        }
    }
}