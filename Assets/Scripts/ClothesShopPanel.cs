using System;
using System.Collections.Generic;
using Patterns;
using UnityEngine;

[Serializable]
public class Wardrobe
{
    public Transform contentPanel
    {
        get => _contentPanel;
        set => _contentPanel = value;
    }
    [SerializeField] private Transform _contentPanel;
    public Transform patternObject
    {
        get => _patternObject;
        set => _patternObject = value;
    }
    [SerializeField] private Transform _patternObject;
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
    
}

public class ClothesShopPanel : MonoBehaviour
{
    [SerializeField] private List<Wardrobe> _clothesPanels;
    
    private void Awake()
    {
        foreach (var clothesPanel in _clothesPanels)
        {
            foreach (var clothes in clothesPanel.Clothes)
            {
                var clone = Instantiate(clothesPanel.patternObject, clothesPanel.contentPanel);
                clone.GetComponent<PatternWardrobe>().ImportData(clothes.Sprite);
            }
        }
    }
}