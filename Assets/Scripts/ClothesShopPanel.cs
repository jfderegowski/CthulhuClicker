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

    public List<Wardrobe> ClothesPanels
    {
        get => _clothesPanels;
        set => _clothesPanels = value;
    }
    [SerializeField] private List<Wardrobe> _clothesPanels;
    
    private void Awake()
    {
        foreach (var clothesPanel in _clothesPanels)
        {
            foreach (var clothes in clothesPanel.Clothes)
            {
                var clone = Instantiate(clothesPanel.PatternObject, clothesPanel.ContentPanel);
                clone.GetComponent<PatternWardrobe>().ImportData(clothes.UIIcon, delegate
                {
                    _audioSource.Play();
                    
                    var itemCard = Instantiate(clothesPanel.PatternItemCard, _contentPanelForItemCard);
                    itemCard.GetComponent<PatternItemPreview>().ButtonBuyText = $"{clothes.Price} Many";
                    
                    if(clothes.IsEquipped)
                        itemCard.GetComponent<PatternItemPreview>().ButtonEquipText = $"Equipped";
                    
                    itemCard.GetComponent<PatternItemPreview>().Import(
                        _audioSource,
                        clothes.Sprite,
                        clothesPanel.ClothesType,
                        clothes.Name,
                        clothes.ItemDescription,
                        delegate
                        {
                            _audioSource.Play();
                            
                            if (clothes.Lvl > 0)
                            {
                                foreach (var clothe in clothesPanel.Clothes)
                                {
                                    clothe.IsEquipped = false;
                                }

                                clothes.IsEquipped = true;
                                _characterDisplay.EquipItem(clothes.Sprite, clothesPanel.ClothesType);
                                
                                itemCard.GetComponent<PatternItemPreview>().ButtonEquipText = $"Equipped";
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
                            
                            if (_pointsManager.Points >= clothes.Price)
                            {
                                clothes.Lvl++;
                                _pointsManager.SubtractPoints(clothes.Price);
                                _updateScoreUI.UpdateUI(_pointsManager.Points);
                                clothes.Price += (ulong)(clothes.Price * 0.15f);
                                itemCard.GetComponent<PatternItemPreview>().ButtonBuyText = $"{clothes.Price} Many";
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