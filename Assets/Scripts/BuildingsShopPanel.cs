using System;
using System.Collections.Generic;
using Patterns;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class Item
{
    public string Name;
    public Sprite Sprite;
    public uint Lvl;
    public GameObject ObjectOnIsland;
}

public class BuildingsShopPanel : MonoBehaviour
{
    [SerializeField] private Transform _shopContentPanel;
    [SerializeField] private Transform _patternObject;
    
    [SerializeField] private List<Item> _items;

    private void Start()
    {
        foreach (var item in _items)
        {
            var clone = Instantiate(_patternObject, _shopContentPanel);
            clone.GetComponent<PatternBuilding>().ImportData(item.Sprite, item.Name, item.Lvl.ToString());
            
            clone.GetChild(2).GetComponent<Button>().onClick.AddListener(delegate
            {
                item.ObjectOnIsland.SetActive(true);
                item.Lvl++;
                clone.GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>().text =
                    $"{item.Name}: {item.Lvl} Lvl.";
            });
        }
    }
}