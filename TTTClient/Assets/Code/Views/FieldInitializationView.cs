using Code.Types;
using UnityEngine;
using UnityEngine.UI;

namespace Code.Views
{
    public class FieldInitializationView : MonoBehaviour
    {
        [SerializeField] private CellView _cellView;
        [SerializeField] private RectTransform _container;

        public void Bind(int count)
        {
            var grid = _container.GetComponent<GridLayoutGroup>();
            grid.constraintCount = count;
        }

        public void SpawnCells(GameData gameData)
        {
            var size = gameData.FieldSize;
            for (var i = 0; i < size * size; i++)
            {
                Instantiate(_cellView, _container);
            }
        }
    }
}