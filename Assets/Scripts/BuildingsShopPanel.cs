using System;
using System.Collections.Generic;
using DG.Tweening;
using Patterns;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class Follower : Item
{
    public uint MaxCount;
    public uint Count;
}

[Serializable]
public class Building : Item
{
    public uint MaxFolowersCount;
    public GameObject ObjectOnIsland;
}

public class BuildingsShopPanel : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private Transform _shopContentPanel;
    [SerializeField] private Transform _patternObject;
    [SerializeField] private PointsManager _pointsManager;
    [SerializeField] private UpdateScoreUI _updateScoreUI;
    [SerializeField] private SpawnNpcs _spawnNpcs;

    public Follower Follower
    {
        get => _follower;
        set => _follower = value;
    }
    [SerializeField] private Follower _follower;

    public List<Building> Buildings
    {
        get => _buildings;
        set => _buildings = value;
    }
    [SerializeField] private List<Building> _buildings;

    private void Start()
    {
        // Followers
        var cloneFollower = Instantiate(_patternObject, _shopContentPanel);
        cloneFollower.GetComponent<PatternBuilding>().ImportData(
            _follower.Sprite,
            $"{_follower.Name}: {_follower.Lvl}",
            $"{_follower.Price} Many"
            );
        
        cloneFollower.GetChild(2).GetComponent<Button>().onClick.AddListener(delegate
        {
            _audioSource.Play();
            
            if (_pointsManager.Points >= _follower.Price && _follower.MaxCount >= _follower.Count)
            {
                _pointsManager.SubtractPoints(_follower.Price);
                _updateScoreUI.UpdateUI(_pointsManager.Points);
                _follower.Price += (ulong)(_follower.Price * 0.15f);
                _follower.Lvl++;
                _follower.Count++;

                cloneFollower.GetComponent<PatternBuilding>().ImportData(
                    $"{_follower.Name}: {_follower.Lvl}\nPosiadasz: {_follower.Count} followers",
                    $"{_follower.Price} Many"
                );
                
                _spawnNpcs.SpawnNpc();
            }
            else
            {
                // Shake button
                cloneFollower.GetChild(2).DOShakeRotation(0.1f, 10f);
            }
        });

        
        // Building list
        foreach (var item in _buildings)
        {
            var clone = Instantiate(_patternObject, _shopContentPanel);
            clone.GetComponent<PatternBuilding>().ImportData(
                item.Sprite,
                $"{item.Name}: {item.Lvl}",
                $"{item.Price} Many"
                );

            clone.GetChild(2).GetComponent<Button>().onClick.AddListener(delegate
            {
                _audioSource.Play();
                
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
                    // Shake button
                    clone.GetChild(2).DOShakeRotation(0.1f, 10f);
                }
            });
        }
    }
}