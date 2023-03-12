using System;
using Code.Types;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Code.Views
{
    public class GameOverView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _description;
        [SerializeField] private Button _button;

        public Action OnClick { get; set; }

        private void OnEnable()
        {
            _button.onClick.AddListener(() => OnClick?.Invoke());
        }

        public void Bind(GameData data)
        {
            if (data.Winner == CellState.Empty)
            {
                _description.text = "DRAW";
                return;
            }
            
            _description.text = $"{data.Winner.ConvertTo()} = WINNER";
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(() => OnClick?.Invoke());
        }
    }
}