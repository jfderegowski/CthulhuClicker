using UnityEngine;

public class GameDataCollector : MonoBehaviour
{
    public PointsManager PointsManager;
    //public ClothesShopPanel ClothesShopPanel;

    public void LoadData(GameData gameData)
    {
        PointsManager.Points = gameData.Points;
        //
        // // Load data to ClothesShopPanel
        // foreach (var clothesPanel in ClothesShopPanel.ClothesPanels)
        // {
        //     for (int i = 0; i < clothesPanel.Clothes.Count; i++)
        //     {
        //         clothesPanel.Clothes[i].Lvl = ClothesShopPanel.ClothesPanels[i].Clothes[i].Lvl;
        //         clothesPanel.Clothes[i].Mps = ClothesShopPanel.ClothesPanels[i].Clothes[i].Mps;
        //         clothesPanel.Clothes[i].Price = ClothesShopPanel.ClothesPanels[i].Clothes[i].Price;
        //     }
        // }
        
    }
}

public class GameData
{
    public ulong Points;
    //public ClothesShopPanel ClothesShopPanel;

    public GameData(GameDataCollector gameDataCollector)
    {
        Points = gameDataCollector.PointsManager.Points;
        //ClothesShopPanel = new ClothesShopPanel(gameDataCollector.ClothesShopPanel);
    }
}