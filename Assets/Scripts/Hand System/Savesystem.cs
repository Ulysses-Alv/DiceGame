using System.IO;
using UnityEngine;

public static class Savesystem
{
    public static readonly string SAVE_FOLDER = Application.dataPath + "/Saves/";
    public static void Init()
    {
        // Test if Save Folder exists
        if (!Directory.Exists(SAVE_FOLDER))
        {
            // Create Save Folder
            Directory.CreateDirectory(SAVE_FOLDER);
        }
    }

    public static void Save(string saveString)
    {
        File.WriteAllText(SAVE_FOLDER + "save.txt", saveString);
    }

    public static string Load()
    {
        if (File.Exists(SAVE_FOLDER + "save.txt"))
        {
            string saveString = File.ReadAllText(SAVE_FOLDER + "save.txt");
            return saveString;
        }
        else
        {
            return null;
        }
    }

  
}
