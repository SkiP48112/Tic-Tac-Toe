using System.Collections.Generic;
using System.Linq;
using Code.Logic.Contracts;
using UnityEngine;

namespace Code.Views
{
    public class RuntimeView : MonoBehaviour
    {
        [SerializeField] private RectTransform _container;
        private readonly Dictionary<int, CellView> _indexToCell = new();

        public void CollectCells()
        {
            var cells = _container.GetComponentsInChildren<CellView>().ToList();
            foreach (var cell in cells)
            {
                _indexToCell.Add(cells.IndexOf(cell), cell);
            }
        }

        public void Bind(IGameManager gameManager)
        {
            gameManager.BindCells(_indexToCell);
            foreach (var tuple in _indexToCell)
            {
                tuple.Value.BindGameManager(gameManager);
                tuple.Value.Bind();
            }
        }
    }
}