using System;
using Patterns;
using UnityEngine;

[Serializable]
public class EquippedItems
{
    [SerializeField] private PatternEquippedItem _equippedItemHat;
    [SerializeField] private PatternEquippedItem _equippedItemShirt;

    public void DisplayEquippedItemInShop(Wardrobe wardrobe, Clothes clothes)
    {
        switch (wardrobe.ClothesType)
        {
            case ItemType.Shirt:
                _equippedItemShirt.ImportData(clothes.UIIcon, $"{clothes.Name}: {clothes.Lvl} Lvl");
                break;
            case ItemType.Hat:
                _equippedItemHat.ImportData(clothes.UIIcon, $"{clothes.Name}: {clothes.Lvl} Lvl");
                break;
            case ItemType.Wings:
                break;
            case ItemType.Body:
                break;
            case ItemType.Eye:
                break;
            default:
                break;
        }
    }
}
