using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FileDataHandler
{
    private string DataDirPath = "";
    
    private string DataFileName = "";

public FileDataHandler(string DataDirPath, string DataFileName)
{
    this.DataDirPath = DataDirPath;
    this.DataFileName = DataFileName;
}

public GameData Load()
{
    // Het pad naar de file waar de data is opgeslagen.
    string FullPath = Path.Combine(DataDirPath, DataFileName);
    GameData LoadedData = null;

    if (File.Exists(FullPath))
    {
        try
        {
            string DataToLoad = "";
            using(FileStream stream = new FileStream(FullPath, FileMode.Open))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    DataToLoad = reader.ReadToEnd();
                }
            }

            LoadedData = JsonUtility.FromJson<GameData>(DataToLoad);
        }
        catch (Exception e)
        {
            Debug.LogError("Error occured when trying to save data to file: " + FullPath + "\n" + e);
        }
    }

    return LoadedData;
}

public void Save(GameData Data)
{
    // Het pad naar de file waar de data is opgeslagen.
    string FullPath = Path.Combine(DataDirPath, DataFileName);

    try
    {
        Directory.CreateDirectory(Path.GetDirectoryName(FullPath));

        string DataToStore = JsonUtility.ToJson(Data, true);

        using(FileStream stream = new FileStream(FullPath, FileMode.Create))
        {
            using (StreamWriter writer = new StreamWriter(stream))
            {
                writer.Write(DataToStore);
            }
        }
    }
    catch (Exception e)
    {
        Debug.LogError("Error occured when trying to save data to file: " + FullPath + "\n" + e);
    }
}

}
