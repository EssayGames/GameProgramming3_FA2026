using System.Collections.Generic;
using UnityEngine;


public class DataManager : MonoBehaviour
{
    public static DataManager instance { get; private set; }
    private List<IDataHandler> dataObjs = new List<IDataHandler>();
    private GameData gameData;
    private FileDataManager fileManager;

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
        this.fileManager = new FileDataManager(Application.persistentDataPath, fileName);
        getAllDataObj();
        LoadGame();
    }

    public void getAllDataObj()
    {
        MonoBehaviour[] allScripts = FindObjectsByType<MonoBehaviour>();
        for(int i = 0; i < allScripts.Length; i++)
        {
            if (allScripts[i] is IDataHandler)
            {
                dataObjs.Add(allScripts[i] as IDataHandler);
            }
        }
    }

    public void NewGame()
    {
        //we're using the GameData class constructor to make sure there is some data stored in this variable
        //before we start overwriting data to it
        this.gameData = new GameData();
    }

    public void LoadGame()
    {
        // TODO: Use the file writing system to deserialize the stored game data on my computer and load into this class
        this.gameData = fileManager.LoadFile();

        if(this.gameData == null)
        {
            Debug.Log("No Game Data Was Found. Loaded default data from NewGame().");
            NewGame();
        }

        Debug.Log("Loaded Player Position: " + gameData.playerPos.ToString());

        // TODO: Take the gameData variable in this class and "push" it to all of my interface instances
        foreach(IDataHandler dataHandler in dataObjs)
        {
            dataHandler.LoadData(gameData);
        }

    }

    public void SaveGame()
    {
        // FINISHED: Get all GameData from interface instances and store in the local gameData variable
        foreach(IDataHandler dataHandler in dataObjs)
        {
            dataHandler.SaveData(ref gameData);
        }

        Debug.Log("Saved Player Position: " + gameData.playerPos.ToString());

        // FINISHED: Use the file writing system to serialize the gameData varialbe into a file on my computer
        fileManager.SaveFile(gameData);
    }

    public void OnApplicationQuit()
    {
        SaveGame();
    }
}
