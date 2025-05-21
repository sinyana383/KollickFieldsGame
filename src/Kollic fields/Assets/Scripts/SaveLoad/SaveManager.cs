using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveManager
{
    static string GetPath(string fileName)
    {
        Debug.Log($"Get path {Application.persistentDataPath + $"/{fileName}.save"}");
        return Application.persistentDataPath + $"/{fileName}.save";
    }

    public static void SaveData<T>(T data, string fileName)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = GetPath(fileName);
        using (FileStream fileStream = new FileStream(path, FileMode.Create))
        {
            formatter.Serialize(fileStream, data);
        }
    }

    public static T LoadData<T>(string fileName) where T : class
    {
        string path = GetPath(fileName);
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fileStream = new FileStream(path, FileMode.Open))
            {
                return formatter.Deserialize(fileStream) as T;
            }
        }
        else
        {
            Debug.LogWarning("Save file not found in " + path);
            return null;
        }
    }
}
