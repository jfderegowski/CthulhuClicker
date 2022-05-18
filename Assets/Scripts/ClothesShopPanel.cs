using System;
using System.Collections.Generic;
using Patterns;
using UnityEngine;

[Serializable]
public class Clothes : Item
{
    
}

public class ClothesShopPanel : MonoBehaviour
{
    [SerializeField] private Transform _contentPanel;
    [SerializeField] private Transform _patternObject;
    [SerializeField] private List<Clothes> _items;


    private void Awake()
    {
        foreach (var item in _items)
        {
            var clone = Instantiate(_patternObject, _contentPanel);
            clone.GetComponent<PatternWardrobe>().ImportData(item.Sprite);
        }
    }
}
