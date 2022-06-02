using System.Collections.Generic;
using UnityEngine;

public class GameDataCollector : MonoBehaviour
{
    public PointsManager PointsManager;
    public ClothesShopPanel ClothesShopPanel;
    public BuildingsShopPanel BuildingsShopPanel;

    public void LoadData(GameData gameData)
    {
        PointsManager.Points = gameData.Points;
        ClothesShopPanel.ClothesPanels = gameData.Wardrobes;
        BuildingsShopPanel.Follower = gameData.Follower;
        BuildingsShopPanel.Buildings = gameData.Buildings;
    }
}

public class GameData
{
    public ulong Points;
    public List<Wardrobe> Wardrobes;
    public Follower Follower;
    public List<Building> Buildings;

    public GameData(GameDataCollector gameDataCollector)
    {
        Points = gameDataCollector.PointsManager.Points;
        Wardrobes = gameDataCollector.ClothesShopPanel.ClothesPanels;
        Follower = gameDataCollector.BuildingsShopPanel.Follower;
        Buildings = gameDataCollector.BuildingsShopPanel.Buildings;
    }
}