using UnityEngine;
using System.Collections.Generic;

public class keyInvetoryManager : MonoBehaviour
{
    public static keyInvetoryManager instance { get; private set; }
    public List<iKeyHandler> allLockedObjs = new List<iKeyHandler>();
    
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
        loadAllLockedObjects();
    }

    //this method loads all of the iKeyHandler interface scripts and stores them into the allLockedObjs List
    //it does this by retrieving all of the MonoBehaviour "objects" in our scene and then separates our the iKeyHandler interfaces

    public void loadAllLockedObjects()
    {
        MonoBehaviour[] allScripts = FindObjectsByType<MonoBehaviour>();
        for(int i = 0; i < allScripts.Length; i++)
        {
            if (allScripts[i] is iKeyHandler)
            {
                allLockedObjs.Add(allScripts[i] as iKeyHandler);
            }
        }
    }

    //the below method goes through each iKeyHandler interface "instance" and calls the canUnlock() method
    //allLockedObjs contains all of the scripts in our scene that use the iKeyHandler interface
    public void collectedKey()
    {
        foreach(iKeyHandler keyHandler in allLockedObjs)
        {
            keyHandler.canUnlock();
        }
    }

    //the below method goes through each iKeyHandler interface "instance" and calls the removeKey() method
    public void usedKey()
    {
        foreach(iKeyHandler keyHandler in allLockedObjs)
        {
            keyHandler.removeKey();
        }
    }



}
