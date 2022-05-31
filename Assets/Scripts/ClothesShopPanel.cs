using System;
using System.Collections.Generic;
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
}

public class ClothesShopPanel : MonoBehaviour
{
    [SerializeField] private PointsManager _pointsManager;
    [SerializeField] private UpdateScoreUI _updateScoreUI;
    
    [SerializeField] private Transform _contentPanelForItemCard;
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
                    var itemCard = Instantiate(clothesPanel.PatternItemCard, _contentPanelForItemCard);
                    itemCard.GetComponent<PatternItemPreview>().Import(
                        clothes.Sprite,
                        clothesPanel.ClothesType,
                        clothes.Name,
                        clothes.ItemDescription,
                        delegate { Debug.Log("buy"); },
                        delegate { Debug.Log("equip"); }
                    );
                });
            }
        }
    }

    private void Buy(ulong price)
    {
        if (_pointsManager.Points >= price)
        {
            
        }
    }
}