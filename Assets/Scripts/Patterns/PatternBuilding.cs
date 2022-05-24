using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Patterns
{
    public class PatternBuilding : MonoBehaviour
    {
        [SerializeField] private Image _sprite;
        [SerializeField] private TextMeshProUGUI _itemDescription;
        [SerializeField] private TextMeshProUGUI _buttonText;

        public void ImportData(Sprite sprite, string itemDescription, string buttonText)
        {
            _sprite.sprite = sprite;
            _itemDescription.text = itemDescription;
            _buttonText.text = buttonText;
        }

        public void ImportData(string itemDescription, string buttonText)
        {
            _buttonText.text = buttonText;
            _itemDescription.text = itemDescription;
        }
    }
}
