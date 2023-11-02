using System.IO;
using UnityEngine;

public static class SaveSystem 
{
    public static readonly string SAVE_FOLDER = Application.persistentDataPath + "/save/"; //tao duong dan save
    public static readonly string FILE_EXT = ".json"; //khai bao kieu save json

    public static void Save(string fileName, string dataToSave) //khai bao ham save
    {
        if (!Directory.Exists(SAVE_FOLDER)) //kiem tra xem save folder ton tai hay chua
        {
            Directory.CreateDirectory(SAVE_FOLDER);  // neu chua thi tao save folder
        }
        File.WriteAllText(SAVE_FOLDER + fileName + FILE_EXT, dataToSave); //save noi dung vao datatosave
    }
    public static string Load(string fileName) //khai bao ham load
    {
        string fileloc = SAVE_FOLDER + fileName + FILE_EXT; //tao string filedoc duong dan toi cho save
        if (File.Exists(SAVE_FOLDER + fileName + FILE_EXT))  //kiem tra duong dan da ton tai hay chua
        {
            string loadData = File.ReadAllText(fileloc); //neu ton tai load save vao string loaddata
            return loadData; // tra ve du lieu chuoi
        }
        else
        {
            return null; //khong thi thoi
        }
    }
}
