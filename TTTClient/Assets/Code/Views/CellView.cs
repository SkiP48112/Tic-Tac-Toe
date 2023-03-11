using Code.Logic.Contracts;
using Code.Types;
using TMPro;
using UnityEngine;
using Button = UnityEngine.UI.Button;

namespace Code.Views
{
    public class CellView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _value;
        [SerializeField] private Button _button;

        private IGameManager _gameManager;

        public void BindGameManager(IGameManager gameManager)
        {
            _gameManager = gameManager;
        }
        
        public void Bind()
        {
           _button.onClick.AddListener(OnButtonClick);
        }

        public CellState GetValue()
        {
            return _value.text.ConvertTo();
        }

        private void OnButtonClick()
        {
            _value.text = _gameManager.GetCurrentState().ConvertTo();
            _gameManager.CheckForGameOver();
            _gameManager.ToggleCurrentState();
            _button.onClick.RemoveListener(OnButtonClick);
        }
    }
}
