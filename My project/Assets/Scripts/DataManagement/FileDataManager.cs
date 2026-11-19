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
        //this string is loading the file path on our local machine
        //the variables in the Path.Combine() method are assigned by the DataManager singleton using the constructor
        string fullPathToFile = Path.Combine(dataDirectoryName, dataFileName);

        //this will be the returned GameData class data, if it's null our DataManager will create new GameData
        GameData loadedData = null;
        
        //checks to see that our file exists and then load the file using the FileStream and FileReader classes from System.IO
        if (File.Exists(fullPathToFile))
        {
            try
            {
                //LOOK at SaveFile() method for documentation on what's happening below
                //the important difference is that we're *de*serializing the data from the local file
                //back into a GameData variable that we're returning when we call this method from DataManager
                string dataToLoad = "";

                using(FileStream stream = new FileStream(fullPathToFile, FileMode.Open))
                {
                    using(StreamReader reader = new StreamReader(stream))
                    {
                        dataToLoad = reader.ReadToEnd();
                    }
                }

                loadedData = JsonUtility.FromJson<GameData>(dataToLoad);
            }
            catch (Exception e)
            {
                Debug.LogError("Error: File Path at: " + fullPathToFile + "cannot be found. Did not load data. \n" + e);
            }

        }

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
