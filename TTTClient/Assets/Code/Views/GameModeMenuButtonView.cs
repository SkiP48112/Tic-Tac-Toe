using System;
using Code.Types;
using UnityEngine;
using UnityEngine.UI;

namespace Code.Views
{
    public class GameModeMenuButtonView : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private GameMode _mode;
        public Action<GameMode> OnClick;
        
        private void OnEnable()
        {
            _button.onClick.AddListener(SendAction);
        }

        private void SendAction()
        {
            OnClick?.Invoke(_mode);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(SendAction);
        }
    }
}