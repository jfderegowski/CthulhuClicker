using System;
using UnityEngine;

public class PointsManager : MonoBehaviour
{
    public ulong Points;

    public BuildingsShopPanel BuildingsShopPanel => _buildingsShopPanel;
    public ClothesShopPanel ClothesShopPanel => _clothesShopPanel;

    [SerializeField] private BuildingsShopPanel _buildingsShopPanel;
    [SerializeField] private ClothesShopPanel _clothesShopPanel;

    public void AddPoints(ulong pointsToAdd)
    {
        Points += pointsToAdd;
    }
    
    public void SubtractPoints(ulong price)
    {
        Points -= price;
    }
}
