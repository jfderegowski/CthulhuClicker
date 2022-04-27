using System.IO;
using UnityEngine;

public class SaveAndLoadGame : MonoBehaviour
{
    [SerializeField] private GameDataCollector _gameDataCollector;
    
    private GameData _gameData;
    private string _savePath;

    private void Start()
    {
        _savePath = $"{Application.dataPath}/Save.json";
        LoadGame();
    }

    private void OnApplicationQuit() => SaveGame();

    private void SaveGame()
    {
        _gameData = new GameData(GetComponent<GameDataCollector>());
        var dataToSave = JsonUtility.ToJson(_gameData);
        File.WriteAllText(_savePath, dataToSave);
    }

    private void LoadGame()
    {
        var dataToLoad = File.ReadAllText(_savePath);
        var gameData = JsonUtility.FromJson<GameData>(dataToLoad);
        _gameDataCollector.LoadData(gameData);
    }
}
