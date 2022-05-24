using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Patterns
{
    public class PatternEquippedItem : MonoBehaviour
    {
        [SerializeField] private Image _image;
        [SerializeField] private TextMeshProUGUI _itemDescription;

        public void ImportData(Sprite sprite, string itemDescription)
        {
            _image.sprite = sprite;
            _itemDescription.text = itemDescription;
        }
    }
}
