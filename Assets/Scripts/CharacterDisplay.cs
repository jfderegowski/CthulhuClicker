using System;
using UnityEngine;
using UnityEngine.UI;

public class CharacterDisplay : MonoBehaviour
{
    public Sprite Wings
    {
        get => _wings.sprite;
        set => _wings.sprite = value;
    }
    public Sprite Body
    {
        get => _body.sprite;
        set => _body.sprite = value;
    }
    public Sprite Eye
    {
        get => _eye.sprite;
        set => _eye.sprite = value;
    }
    public Sprite Shirt
    {
        get => _shirt.sprite;
        set => _shirt.sprite = value;
    }
    public Sprite Hat
    {
        get => _hat.sprite;
        set => _hat.sprite = value;
    }
    
    [SerializeField] private Image _wings;
    [SerializeField] private Image _body;
    [SerializeField] private Image _eye;
    [SerializeField] private Image _shirt;
    [SerializeField] private Image _hat;

    public void EquipItem(Sprite sprite, ItemType itemType)
    {
        switch (itemType)
        {
            case ItemType.Hat:
                _hat.sprite = sprite;
                break;
            case ItemType.Shirt:
                _shirt.sprite = sprite;
                break;
            case ItemType.Wings:
                _wings.sprite = sprite;
                break;
            case ItemType.Body:
                _body.sprite = sprite;
                break;
            case ItemType.Eye:
                _eye.sprite = sprite;
                break;
            default:
                break;
        }
    }
}
