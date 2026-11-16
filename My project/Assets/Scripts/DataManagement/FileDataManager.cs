using UnityEngine;
using System;
using System.IO;

public class FileDataManager
{
    private string dataDirectoryName = "";
    private string dataFileName = "";
    
    //this constructor 'loads' two strings into the private variables of this class
    //we will call this contructor from the DataManager singleton and pass two strings as arguments
    public FileDataManager(string dataDirPath, string dataFName)
    {
        this.dataDirectoryName = dataDirPath;
        this.dataFileName = dataFName;
    }

    public GameData LoadFile()
    {
        GameData loadedData = null;

        return loadedData;
    }

    public void SaveFile(GameData data)
    {
        string fullPathToFile = Path.Combine(dataDirectoryName, dataFileName);
        
        try
        {
            //creates the directory on my local machine that I want to write my file to
            Directory.CreateDirectory(Path.GetDirectoryName(fullPathToFile));

            //converting the GameData `data` varaible passed as an argument into this method
            //into a JSON serializable string, we will use this string to write to a file
            string dataToStore = JsonUtility.ToJson(data, true);

            //the using block below safely ensures that we don't cause any data leaks while writing our dataToString string
            //to a JSON file on our computer at the `fullPathToFile` directory location

            //FileStream and StreamWriter are both datatypes unique to System.IO, they allow us to "stream" data
            //to a location on our computer and write data to that stream
            using (FileStream stream = new FileStream(fullPathToFile, FileMode.Create))
            {
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    writer.Write(dataToStore);
                }
            }
        }
        catch(Exception e)
        {
            Debug.LogError("Error: File Path at " + fullPathToFile + "does not exist. Not able to write data. \n" + e);
        }
    }
}
