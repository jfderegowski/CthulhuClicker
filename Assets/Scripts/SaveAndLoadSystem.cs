using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveAndLoadSystem
{
    public static void SaveGameData(GameData gameData)
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        string path = $"{Application.persistentDataPath}/GameData.bin";
        FileStream fileStream = new FileStream(path, FileMode.Create);

        GameData dataToSave = new GameData(gameData);
        
        binaryFormatter.Serialize(fileStream, gameData);
        fileStream.Close();
    }

    public static GameData LoadGameData()
    {
        string path = $"{Application.persistentDataPath}/GameData.bin";

        if (File.Exists(path))
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream fileStream = new FileStream(path, FileMode.Open);
            
            GameData dataToLoad = binaryFormatter.Deserialize(fileStream) as GameData;
            fileStream.Close();

            return dataToLoad;
        }
        else
        {
            Debug.LogError($"Save game file not found in {path}");
            return null;
        }
    }
}
