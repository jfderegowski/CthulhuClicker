using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class Item
{
    public string Name;
    public Sprite Sprite;
    public uint Lvl;
}

[Serializable]
public class ShopPanel
{
    public Transform ShopContentPanel;
    public Transform PatternObject;
    public List<Item> Items;
}

public class ItemDisplay : MonoBehaviour
{
    [SerializeField] private List<ShopPanel> _shopPanels;

    private void Start()
    {
        foreach (var shopPanel in _shopPanels)
        {
            foreach (var item in shopPanel.Items)
            {
                var clone = Instantiate(shopPanel.PatternObject, shopPanel.ShopContentPanel);
                clone.GetChild(0).GetComponent<Image>().sprite = item.Sprite;
                clone.GetChild(1).GetComponent<TextMeshProUGUI>().text = item.Name;
                clone.GetChild(2).GetComponent<Button>();
                clone.GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>().text = item.Lvl.ToString();
            }
        }
    }
}