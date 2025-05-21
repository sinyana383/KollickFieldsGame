using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveManager
{
    static string GetPath()
    {
        Debug.Log($"Get path {Application.persistentDataPath}");
        return Application.persistentDataPath + "/gameState.save";
    }
    public static void SaveGameState(GameState gameState) 
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = GetPath();
        FileStream fileStream = new FileStream(path, FileMode.Create);

        SaveData.GameStateData data = new SaveData.GameStateData(gameState);

        formatter.Serialize(fileStream, data);
        fileStream.Close();
    }

    public static SaveData.GameStateData LoadGameState()
    {
        string path = GetPath();
        if (File.Exists(path))
        { 
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream fileStream = new FileStream(path, FileMode.Open);

            SaveData.GameStateData gameStateData = binaryFormatter.Deserialize(fileStream) as SaveData.GameStateData;
            fileStream.Close();
            return gameStateData;
        }
        else 
        {
            Debug.LogWarning("Save file not found in " +  path);
            return null;
        }
    }
}
