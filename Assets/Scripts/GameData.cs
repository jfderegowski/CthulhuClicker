using UnityEngine;

[System.Serializable]
public class GameData : MonoBehaviour
{
    public long Points;

    public GameData(long points)
    {
        Points = points;
    }
}
