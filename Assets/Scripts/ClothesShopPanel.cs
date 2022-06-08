using System;
using System.Collections.Generic;
using DG.Tweening;
using Patterns;
using UnityEngine;

[Serializable]
public class Wardrobe
{ 
    public Transform ContentPanel
    {
        get => _contentPanel;
        set => _contentPanel = value;
    }
    [SerializeField] private Transform _contentPanel;
    public Transform PatternObject
    {
        get => _patternObject;
        set => _patternObject = value;
    }
    [SerializeField] private Transform _patternObject;
    public Transform PatternItemCard
    {
        get => _patternItemCard;
        set => _patternItemCard = value;
    }
    [SerializeField] private Transform _patternItemCard;

    public ItemType ClothesType => _clothesType;
    [SerializeField] private ItemType _clothesType;
    
    public List<Clothes> Clothes
    {
        get => _clothes;
        set => _clothes = value;
    }
    [SerializeField] private List<Clothes> _clothes;
}

[Serializable]
public class Clothes : Item
{
    public string ItemDescription => _itemDescription;
    [SerializeField] [TextArea] private string _itemDescription;
    public Sprite UIIcon => _uIIcon;
    [SerializeField] private Sprite _uIIcon;

    public bool IsEquipped
    {
        get => _isEquipped;
        set => _isEquipped = value;
    }
    [SerializeField] private bool _isEquipped;
}

public class ClothesShopPanel : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private CharacterDisplay _characterDisplay;
    [SerializeField] private PointsManager _pointsManager;
    [SerializeField] private UpdateScoreUI _updateScoreUI;
    [SerializeField] private Transform _contentPanelForItemCard;

    [SerializeField] private EquippedItems _equippedItems;
    public List<Wardrobe> ClothesPanels
    {
        get => _clothesPanels;
        set => _clothesPanels = value;
    }
    [SerializeField] private List<Wardrobe> _clothesPanels;
    
    private void Awake()
    {
        for (int clothesPanel = 0; clothesPanel < _clothesPanels.Count; clothesPanel++)
        {
            for (int clothes = 0; clothes < _clothesPanels[clothesPanel].Clothes.Count; clothes++)
            {
                var tmpClothesPanel = clothesPanel;
                var tmpClothes = clothes;
                
                var clone = Instantiate(_clothesPanels[clothesPanel].PatternObject, _clothesPanels[clothesPanel].ContentPanel);
                
                clone.GetComponent<PatternWardrobe>().ImportData(_clothesPanels[clothesPanel].Clothes[clothes].UIIcon, delegate
                {
                    _audioSource.Play();
                    
                    var itemCard = Instantiate(_clothesPanels[tmpClothesPanel].PatternItemCard, _contentPanelForItemCard);
                    
                    itemCard.GetComponent<PatternItemPreview>().ButtonBuyText = $"{_clothesPanels[tmpClothesPanel].Clothes[tmpClothes].Price} Many";
                    
                     if(_clothesPanels[tmpClothesPanel].Clothes[tmpClothes].IsEquipped)
                         itemCard.GetComponent<PatternItemPreview>().ButtonEquipText = $"Equipped";
                    
                     itemCard.GetComponent<PatternItemPreview>().Import(
                         _audioSource,
                         _clothesPanels[tmpClothesPanel].Clothes[tmpClothes].Sprite,
                         _clothesPanels[tmpClothesPanel].ClothesType,
                         _clothesPanels[tmpClothesPanel].Clothes[tmpClothes].Name,
                         _clothesPanels[tmpClothesPanel].Clothes[tmpClothes].ItemDescription, 
                         delegate
                         {
                             _audioSource.Play();
                             
                             if (_clothesPanels[tmpClothesPanel].Clothes[tmpClothes].Lvl > 0)
                             {
                                 foreach (var t in _clothesPanels[tmpClothesPanel].Clothes)
                                 {
                                     t.IsEquipped = false;
                                 }
                    
                                 _clothesPanels[tmpClothesPanel].Clothes[tmpClothes].IsEquipped = true;
                                 _characterDisplay.EquipItem(_clothesPanels[tmpClothesPanel].Clothes[tmpClothes].Sprite, _clothesPanels[tmpClothesPanel].ClothesType);
                                 
                                 itemCard.GetComponent<PatternItemPreview>().ButtonEquipText = $"Equipped";
                                 
                                 _equippedItems.DisplayEquippedItemInShop(_clothesPanels[tmpClothesPanel], _clothesPanels[tmpClothesPanel].Clothes[tmpClothes]);
                             }
                             else
                             {
                                 //Button shake
                                 itemCard.GetComponent<PatternItemPreview>().ButtonEquipTransform
                                     .DOShakeRotation(0.1f, 10f);
                             }
                         },
                         delegate
                         {
                             _audioSource.Play();
                             
                             if (_pointsManager.Points >= _clothesPanels[tmpClothesPanel].Clothes[tmpClothes].Price)
                             {
                                 _clothesPanels[tmpClothesPanel].Clothes[tmpClothes].Lvl++;
                                 _pointsManager.SubtractPoints(_clothesPanels[tmpClothesPanel].Clothes[tmpClothes].Price);
                                 _updateScoreUI.UpdateUI(_pointsManager.Points);
                                 _clothesPanels[tmpClothesPanel].Clothes[tmpClothes].Price += (ulong)(_clothesPanels[tmpClothesPanel].Clothes[tmpClothes].Price * 0.15f);
                                 itemCard.GetComponent<PatternItemPreview>().ButtonBuyText = $"{_clothesPanels[tmpClothesPanel].Clothes[tmpClothes].Price} Many";
                             }
                             else
                             {
                                 //Button shake
                                 itemCard.GetComponent<PatternItemPreview>().ButtonBuyTransform
                                     .DOShakeRotation(0.1f, 10f);
                             }
                         }
                     );
                });
            }
        }
    }
}