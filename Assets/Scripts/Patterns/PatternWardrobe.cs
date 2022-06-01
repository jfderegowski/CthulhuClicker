using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Patterns
{
    public class PatternWardrobe : MonoBehaviour
    {
        [SerializeField] private Image _image;
        [SerializeField] private Button _button;

        public void ImportData(Sprite sprite, UnityAction onButtonClicked)
        {
            _image.sprite = sprite;
            _button.onClick.AddListener(onButtonClicked);
        }
    }
}
