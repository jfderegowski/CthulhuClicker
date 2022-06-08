using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace SaveGameSystem
{
    public class CheckBuyedClothes
    {
        public void IsBuyed(List<Wardrobe> wardrobes, EquippedItems equippedItems, CharacterDisplay characterDisplay)
        {
            foreach (var wardrobe in wardrobes)
            {
                foreach (var clothe in wardrobe.Clothes.Where(clothe => clothe.IsEquipped))
                {
                    equippedItems.DisplayEquippedItemInShop(wardrobe, clothe);
                    characterDisplay.EquipItem(clothe.Sprite, wardrobe.ClothesType);
                }
            }
        }
    }
}
