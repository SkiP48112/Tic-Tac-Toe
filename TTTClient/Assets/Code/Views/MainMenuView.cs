using System;
using System.Collections.Generic;
using UnityEngine;

namespace Code.Views
{
    public class MainMenuView : MonoBehaviour
    {
        [SerializeField] private List<MainMenuButtonView> _buttons;
        public Action<int> OnSelected;

        private void OnEnable()
        {
            foreach (var button in _buttons)
            {
                button.OnClick += OnFieldSizeSelected;
            }
        }

        private void OnFieldSizeSelected(int data)
        {
            OnSelected?.Invoke(data);
        }
        
        private void OnDisable()
        {
            foreach (var button in _buttons)
            {
                button.OnClick -= OnFieldSizeSelected;
            }
        }
    }
}