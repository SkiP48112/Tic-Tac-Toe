using Code.Types;
using TMPro;
using UnityEngine;

namespace Code.Views
{
    public class GameOverView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _description;
        public void Bind(GameData data)
        {
            _description.text = $"{data.Winner.ConvertTo()} = winner";
        }
    }
}