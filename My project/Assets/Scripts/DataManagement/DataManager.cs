using UnityEngine;
using System.Collections.Generic;

public class DataManager : MonoBehaviour
{
    public static DataManager instance { get; private set;  }
    private GameData gameData;
    private List<IDataHandler> dataObjs = new List<IDataHandler>();

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
        getAllDataObjs();
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

        //TODO: Push the gameData to all of our interface instances
        foreach(IDataHandler dataHandler in dataObjs)
        {
            dataHandler.LoadData(gameData);
        }
    }

    public void SaveGame()
    {
        //TODO: Retrieve all gameData from our interface instances
        foreach(IDataHandler dataHandler in dataObjs)
        {
            dataHandler.SaveData(ref gameData);
        }

        //TODO: Use The FileSystem class to serialize our gameData into a JSON File
    }

    public void OnApplicationQuit()
    {
        SaveGame();
    }


}
