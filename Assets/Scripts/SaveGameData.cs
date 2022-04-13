using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveGameData : MonoBehaviour
{
    public static void Save(long points)
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        string path = $"{Application.persistentDataPath}/GameData.bin";
        FileStream fileStream = new FileStream(path, FileMode.Create);

        GameData gameData = new GameData(points);
        
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
            
            GameData gameData = binaryFormatter.Deserialize(fileStream) as GameData;
            fileStream.Close();

            return gameData;
        }
        else
        {
            Debug.LogError($"Save game file not found in {path}");
            return null;
        }
    }
}
