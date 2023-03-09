using System;
using UnityEngine;
using UnityEngine.UI;

namespace Code.Views
{
    public class InitializationView : MonoBehaviour
    {
        [SerializeField] private Button _button;
        public Action OnInitialized;
        
        private void OnEnable()
        {
            _button.onClick.AddListener(OnInitialize);
        }

        private void OnInitialize()
        {
            OnInitialized?.Invoke();
        }
        
        private void OnDisable()
        {
            _button.onClick.AddListener(OnInitialize);
        }
    }
}