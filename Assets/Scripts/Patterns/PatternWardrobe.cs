using UnityEngine;
using UnityEngine.UI;

public class PatternWardrobe : MonoBehaviour
{
    [SerializeField] private Image _image;

    public void ImportData(Sprite sprite)
    {
        _image.sprite = sprite;
    }
}