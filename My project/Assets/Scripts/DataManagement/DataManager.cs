using UnityEngine;
using System.Collections.Generic;

public class DataManager : MonoBehaviour
{
    public static DataManager instance { get; private set;  }
    private GameData gameData;
    private List<IDataHandler> dataObjs = new List<IDataHandler>();
    private FileDataManager fileSystem;

    [SerializeField]
    private string fileName;

    public void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    public void Start()
    {
        //we set the fileSystem variable to the persistentDataPath and filename strings
        //using the constructor of the FileDataManager class
        this.fileSystem = new FileDataManager(Application.persistentDataPath, fileName);
        getAllDataObjs();
        LoadGame();
    }

    public void getAllDataObjs()
    {
        MonoBehaviour[] allScript = FindObjectsByType<MonoBehaviour>();
        for(int i = 0; i < allScript.Length; i++)
        {
            if (allScript[i] is IDataHandler)
            {
                dataObjs.Add(allScript[i] as IDataHandler);
            }
        }

    }

    public void NewGame()
    {
        //when we make a "New Game" we load a GameData class with the constructor's default values
        this.gameData = new GameData();
    }

    public void LoadGame()
    {
        //TODO: The FileSystem class deserialize our gameData and load into this class
        this.gameData = fileSystem.LoadFile();

        if(this.gameData == null)
        {
            Debug.Log("No Game Data Found. Loading default data from class constructor.");
            NewGame();
        }

        //FINISHED: Push the gameData to all of our interface instances
        foreach(IDataHandler dataHandler in dataObjs)
        {
            dataHandler.LoadData(gameData);
        }

        Debug.Log("Loaded Player Position: " + gameData.playerPos.ToString());
    }

    public void SaveGame()
    {
        //TODO: Retrieve all gameData from our interface instances
        foreach(IDataHandler dataHandler in dataObjs)
        {
            dataHandler.SaveData(ref gameData);
        }

        Debug.Log("Saved Player Position: " + gameData.playerPos.ToString());

        //TODO: Use The FileSystem class to serialize our gameData into a JSON File
        fileSystem.SaveFile(gameData);
    }

    public void OnApplicationQuit()
    {
        SaveGame();
    }


}
