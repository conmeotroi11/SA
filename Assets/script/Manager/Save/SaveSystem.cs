using System.IO;
using UnityEngine;

public static class SaveSystem 
{
    public static readonly string SAVE_FOLDER = Application.persistentDataPath + "/save/"; 
    public static readonly string FILE_EXT = ".json"; 

    public static void Save(string fileName, string dataToSave) 
    {
        if (!Directory.Exists(SAVE_FOLDER)) 
        {
            Directory.CreateDirectory(SAVE_FOLDER); 
        }
        File.WriteAllText(SAVE_FOLDER + fileName + FILE_EXT, dataToSave);
    }
    public static string Load(string fileName) 
    {
        string fileloc = SAVE_FOLDER + fileName + FILE_EXT; 
        if (File.Exists(SAVE_FOLDER + fileName + FILE_EXT))  
        {
            string loadData = File.ReadAllText(fileloc); 
            return loadData; 
        }
        else
        {
            return null;
        }
    }
}
