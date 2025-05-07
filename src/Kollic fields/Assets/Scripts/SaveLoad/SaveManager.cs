using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveManager
{
    static string GetPath() => Application.persistentDataPath + "/gameState.save";
    public static void SaveGameState(GameState gameState) 
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = GetPath();
        FileStream fileStream = new FileStream(path, FileMode.Create);

        GameStateData data = new GameStateData(gameState);

        formatter.Serialize(fileStream, data);
        fileStream.Close();
    }

    public static GameStateData LoadGameState()
    {
        string path = GetPath();
        if (File.Exists(path))
        { 
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream fileStream = new FileStream(path, FileMode.Open);

            GameStateData gameStateData = binaryFormatter.Deserialize(fileStream) as GameStateData;
            fileStream.Close();
            return gameStateData;
        }
        else 
        {
            Debug.LogError("Save file not found in " +  path);
            return null;
        }
    }
}
