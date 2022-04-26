using UnityEngine;

[System.Serializable]
public class GameData : MonoBehaviour
{
    public long Points;

    public GameData(GameData gameData)
    {
        Points = gameData.Points;
    }
}