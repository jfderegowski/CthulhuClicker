using System;
using Patterns;
using UnityEngine;

[Serializable]
public class EquippedItems
{
    [SerializeField] private PatternEquippedItem _equippedItemHat;
    [SerializeField] private PatternEquippedItem _equippedItemShirt;
    [SerializeField] private PatternEquippedItem _equippedItemWings;
    [SerializeField] private PatternEquippedItem _equippedItemBody;
    [SerializeField] private PatternEquippedItem _equippedItemEye;

    public void DisplayEquippedItemInShop(Wardrobe wardrobe, Clothes clothes)
    {
        switch (wardrobe.ClothesType)
        {
            case ItemType.Shirt:
                _equippedItemShirt.ImportData(clothes.UIIcon, $"{clothes.Name}: {clothes.Lvl} Lvl");
                _equippedItemShirt.gameObject.SetActive(true);
                break;
            case ItemType.Hat:
                _equippedItemHat.ImportData(clothes.UIIcon, $"{clothes.Name}: {clothes.Lvl} Lvl");
                _equippedItemHat.gameObject.SetActive(true);
                break;
            case ItemType.Wings:
                _equippedItemWings.ImportData(clothes.UIIcon, $"{clothes.Name}: {clothes.Lvl} Lvl");
                _equippedItemWings.gameObject.SetActive(true);
                break;
            case ItemType.Body:
                _equippedItemBody.ImportData(clothes.UIIcon, $"{clothes.Name}: {clothes.Lvl} Lvl");
                _equippedItemBody.gameObject.SetActive(true);
                break;
            case ItemType.Eye:
                _equippedItemEye.ImportData(clothes.UIIcon, $"{clothes.Name}: {clothes.Lvl} Lvl");
                _equippedItemEye.gameObject.SetActive(true);
                break;
            default:
                break;
        }
    }
}
