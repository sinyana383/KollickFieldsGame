using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveManager
{
    private static string IndexPath => Application.persistentDataPath + "/save_index.txt";
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
        if (!fileName.Equals("settingsManager"))
            AddToIndex(fileName);
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
    
    public static void DeleteAllSaves()
    {
        if (File.Exists(IndexPath))
        {
            var allFiles = File.ReadAllLines(IndexPath);
            foreach (var fileName in allFiles)
            {
                string path = GetPath(fileName);
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
            }

            File.Delete(IndexPath);
            Debug.Log("All saves deleted.");
        }
    }
    
    public static List<string> GetSavedFileNames()
    {
        if (File.Exists(IndexPath))
            return new List<string>(File.ReadAllLines(IndexPath));
        else
            return new List<string>();
    }

    private static void AddToIndex(string fileName)
    {
        var list = GetSavedFileNames();
        if (!list.Contains(fileName))
        {
            File.AppendAllLines(IndexPath, new[] { fileName });
        }
    }
}
