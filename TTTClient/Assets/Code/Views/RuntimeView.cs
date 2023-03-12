using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Code.Logic.Contracts;
using Code.Types;
using UnityEngine;
using Random = System.Random;

namespace Code.Views
{
    public class RuntimeView : MonoBehaviour
    {
        [SerializeField] private RectTransform _container;
        [SerializeField] private AIView _firstAI;
        [SerializeField] private AIView _secondAI;
        
        private readonly Dictionary<int, CellView> _indexToCell = new();
        private IGameManager _gameManager;
        private GameMode _gameMode;
        private bool _canMakeATurn = true;

        public void CollectCells()
        {
            var cells = _container.GetComponentsInChildren<CellView>().ToList();
            foreach (var cell in cells)
            {
                _indexToCell.Add(cells.IndexOf(cell), cell);
            }
        }

        public void BindGameMode(GameMode gameMode)
        {
            _gameMode = gameMode;
        }

        public void Bind(IGameManager gameManager)
        {
            _gameManager = gameManager;
            gameManager.BindCells(_indexToCell);
            foreach (var tuple in _indexToCell)
            {
                tuple.Value.BindGameManager(gameManager);
                if (_gameMode != GameMode.CvC)
                {
                    tuple.Value.Bind();
                }
            }
        }

        private void Update()
        {
            if (_gameMode == GameMode.PvC)
            {
                if (_gameManager.GetCurrentState() == _firstAI.GetValue())
                {
                    var index = _gameManager.Turn(_indexToCell, _firstAI.GetValue());
                    if (index == -1)
                    {
                        return;
                    }
                    
                    _indexToCell[index].SetValue(_firstAI.GetValue());
                    if (!_gameManager.CheckForGameOver())
                    {
                        _gameManager.ToggleCurrentState();
                    }
                }
            }
            else if(_gameMode == GameMode.CvC && _canMakeATurn)
            {
                if (_gameManager.GetCurrentState() == _firstAI.GetValue())
                {
                    _indexToCell[_gameManager.Turn(_indexToCell, _firstAI.GetValue())].SetValue(_firstAI.GetValue());
                    if (!_gameManager.CheckForGameOver())
                    {
                        _gameManager.ToggleCurrentState();
                    }

                    StartCoroutine(Thinking());
                }
                else if(_gameManager.GetCurrentState() == _secondAI.GetValue())
                {
                    _indexToCell[_gameManager.Turn(_indexToCell, _secondAI.GetValue())].SetValue(_secondAI.GetValue());
                    if (!_gameManager.CheckForGameOver())
                    {
                        _gameManager.ToggleCurrentState();
                    }
                    
                    StartCoroutine(Thinking());
                }
            }
        }

        IEnumerator Thinking()
        {
            _canMakeATurn = false;
            var r = new Random().Next(0, 10);
            var time = r / 10.0f;

            yield return new WaitForSeconds(time);
            _canMakeATurn = true;
        }
    }
}