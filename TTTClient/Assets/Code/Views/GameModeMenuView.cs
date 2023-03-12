using System;
using System.Collections.Generic;
using Code.Types;
using UnityEngine;

namespace Code.Views
{
    public class GameModeMenuView : MonoBehaviour
    {
        [SerializeField] private List<GameModeMenuButtonView> _buttons;
        public Action<GameMode> OnSelected;

        private void OnEnable()
        {
            foreach (var button in _buttons)
            {
                button.OnClick += OnGameModeSelected;
            }
        }

        private void OnGameModeSelected(GameMode data)
        {
            OnSelected?.Invoke(data);
        }
        
        private void OnDisable()
        {
            foreach (var button in _buttons)
            {
                button.OnClick -= OnGameModeSelected;
            }
        }
    }
}