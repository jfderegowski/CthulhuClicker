using System.IO;
using UnityEngine;

public class SaveAndLoadGame : MonoBehaviour
{
    private GameDataCollector _gameDataCollector;
    private GameData _gameData;
    private string _savePath;

    private void Start()
    {
        _gameDataCollector = GetComponent<GameDataCollector>();
        _savePath = $"{Application.dataPath}/Save.json";
        LoadGame();
    }

    private void OnApplicationQuit() => SaveGame();

    private void SaveGame()
    {
        _gameData = new GameData(_gameDataCollector);
        var dataToSave = JsonUtility.ToJson(_gameData, true);
        File.WriteAllText(_savePath, dataToSave);
    }

    private void LoadGame()
    {
        if (!File.Exists(_savePath)) return;
        
        var dataToLoad = File.ReadAllText(_savePath);
        var gameData = JsonUtility.FromJson<GameData>(dataToLoad);
        _gameDataCollector.LoadData(gameData);
    }
}
