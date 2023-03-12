using System.Collections.Generic;
using Code.Types;
using ModestTree;
using UnityEngine;

namespace Code.Views
{
    public class AIView : MonoBehaviour
    {
        [SerializeField] private CellState _value = CellState.Empty;
        [SerializeField] private RectTransform _container;

        private readonly Dictionary<int, CellView> _cells = new();
        
        public void CollectCells()
        {
            var cells = _container.GetComponentsInChildren<CellView>();
            foreach (var cell in cells)
            {
                _cells.Add(cells.IndexOf(cell), cell);
            }
        }

        public CellState GetValue()
        {
            return _value;
        }
    }
}