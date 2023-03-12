using System;
using UnityEngine;
using UnityEngine.UI;

namespace Code.Views
{
    public class MainMenuButtonView : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private int _fieldSize;
        public Action<int> OnClick;

        private void OnEnable()
        {
            _button.onClick.AddListener(SendAction);
        }

        private void SendAction()
        {
            OnClick?.Invoke(_fieldSize);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(SendAction);
        }
    }
}