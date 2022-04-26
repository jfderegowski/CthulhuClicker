using UnityEngine;

public class SaveAndLoadGame : MonoBehaviour
{
    private GameData _gameData;

    private void OnEnable()
    {
        GameData loadedGameData = SaveAndLoadSystem.LoadGameData();

        _gameData = GetComponent<GameData>();
        _gameData = loadedGameData;
    }

    private void OnDisable()
    {
        _gameData = GetComponent<GameData>();
        
        SaveAndLoadSystem.SaveGameData(_gameData);
    }
}
