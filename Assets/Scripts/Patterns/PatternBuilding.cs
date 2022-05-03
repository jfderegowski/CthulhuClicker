using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Patterns
{
    public class PatternBuilding : MonoBehaviour
    {
        [SerializeField] private Image _sprite;
        [SerializeField] private TextMeshProUGUI _text;
        [SerializeField] private TextMeshProUGUI _buttonText;

        public void ImportData(Sprite sprite, string text, string buttonText)
        {
            _sprite.sprite = sprite;
            _text.text = text;
            _buttonText.text = buttonText;
        }
    }
}
