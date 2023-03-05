using System;
using System.Collections.Generic;
using Code.Logic.Contracts;
using UnityEngine;

namespace Code.Views
{
    public class MainMenuView : MonoBehaviour
    {
        private readonly IMainMenuController _mainMenuController;
        [SerializeField] private List<MainMenuButtonView> _buttons;
        public Action<int> OnSelected;

        public MainMenuView(IMainMenuController mainMenuController)
        {
            _mainMenuController = mainMenuController;
        }

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