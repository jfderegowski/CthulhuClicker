using UnityEngine;

public class GameDataCollector : MonoBehaviour
{
    public PointsManager PointsManager;

    public void LoadData(GameData gameData)
    {
        PointsManager.Points = gameData.Points;
    }
}

public class GameData
{
    public ulong Points;
    

    public GameData(GameDataCollector gameDataCollector)
    {
        Points = gameDataCollector.PointsManager.Points;
    }
}