using System;
using UnityEngine;

public class PointsManager : MonoBehaviour
{
    public ulong Points;

    [SerializeField] private BuildingsShopPanel _buildingsShopPanel;
    [SerializeField] private ClothesShopPanel _clothesShopPanel;

    public void AddPoints()
    {
        Points += CountPointsToAdd();
    }

    public ulong CountPointsToAdd()
    {
        ulong toAdd = _buildingsShopPanel.Follower.Mps + 1;
        return toAdd;
    }

    public void SubtractPoints(ulong price)
    {
        Points -= price;
    }
}
