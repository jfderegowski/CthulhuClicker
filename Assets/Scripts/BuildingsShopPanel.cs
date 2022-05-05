using System;
using System.Collections.Generic;
using DG.Tweening;
using Patterns;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class Follower
{
    public string Name;
    public ulong Price;
    public uint Lvl;
    public ulong Mps;
    public uint MaxCount;
    public uint Count;
    public Sprite Sprite;
}

[Serializable]
public class Item
{
    public string Name;
    public ulong Price;
    public uint Lvl;
    public ulong Mps;
    public uint MaxFolowersCount;
    public Sprite Sprite;
    public GameObject ObjectOnIsland;
}

public class BuildingsShopPanel : MonoBehaviour
{
    [SerializeField] private Transform _shopContentPanel;
    [SerializeField] private Transform _patternObject;
    [SerializeField] private PointsManager _pointsManager;
    [SerializeField] private UpdateScoreUI _updateScoreUI;

    [SerializeField] private Follower _follower;
    [SerializeField] private List<Item> _items;

    private void Start()
    {
        // follower
        var cloneFollower = Instantiate(_patternObject, _shopContentPanel);
        cloneFollower.GetComponent<PatternBuilding>().ImportData(
            _follower.Sprite,
            $"{_follower.Name}: {_follower.Lvl}",
            $"{_follower.Price} Many"
            );
        
        cloneFollower.GetChild(2).GetComponent<Button>().onClick.AddListener(delegate
        {
            if (_pointsManager.Points >= _follower.Price)
            {
                _follower.Lvl++;
                _follower.Count++;
                _pointsManager.SubtractPoints(_follower.Price);
                _updateScoreUI.UpdateUI(_pointsManager.Points);
                _follower.Price += (ulong)(_follower.Price * 0.15f);

                cloneFollower.GetComponent<PatternBuilding>().ImportData(
                    $"{_follower.Name}: {_follower.Lvl}\nPosiadasz: {_follower.Count} followers",
                    $"{_follower.Price} Many"
                );
            }
            else
            {
                //animacja trzęsienia sie przycisku
                cloneFollower.GetChild(2).DOShakeRotation(0.1f, 10f);
            }
        });

        
        // lista itemów
        foreach (var item in _items)
        {
            var clone = Instantiate(_patternObject, _shopContentPanel);
            clone.GetComponent<PatternBuilding>().ImportData(
                item.Sprite,
                $"{item.Name}: {item.Lvl}",
                $"{item.Price} Many"
                );

            clone.GetChild(2).GetComponent<Button>().onClick.AddListener(delegate
            {
                if (_pointsManager.Points >= item.Price)
                {
                    item.Lvl++;
                    _pointsManager.SubtractPoints(item.Price);
                    _updateScoreUI.UpdateUI(_pointsManager.Points);
                    item.Price += (ulong)(item.Price * 0.15f);

                    _follower.MaxCount += item.MaxFolowersCount;
                    
                    clone.GetComponent<PatternBuilding>().ImportData(
                        $"{item.Name}: {item.Lvl}",
                        $"{item.Price} Many"
                        );
                    
                    if (item.ObjectOnIsland != null)
                        item.ObjectOnIsland.SetActive(true);
                }
                else
                {
                    //animacja trzęsienia sie przycisku
                    clone.GetChild(2).DOShakeRotation(0.1f, 10f);
                }
            });
        }
    }
}