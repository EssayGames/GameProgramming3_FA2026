using System.Collections.Generic;
using UnityEngine;

public class keyInventoryManager : MonoBehaviour
{
    //this singleton uses a looping logic to gather all of the classes in our scene that use
    //the `iKeyHandler` interface, and loads them into a list that we can iterate through
    public static keyInventoryManager instance { get; private set; }
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
        refreshLockedObjs();
    }

    //the below method is called in the Start() and loads our allLockedObjs list
    //with all classes that contain the `iKeyHandler` interface
    public void refreshLockedObjs()
    {
        MonoBehaviour[] allScript = FindObjectsByType<MonoBehaviour>();
        for(int i = 0; i< allScript.Length; i++)
        {
            if (allScript[i] is iKeyHandler)
            {
                allLockedObjs.Add(allScript[i] as iKeyHandler);
            }
        }
    }

    //this method is called when we collect a key in our scene
    public void collectedKey()
    {
        foreach(iKeyHandler keyHandler in allLockedObjs)
        {
            keyHandler.canUnlock();
        }
    }

    //the method WILL BE called when we use a key on a Treasure Chest (or lockedObj class)
    public void usedKey()
    {
        foreach(iKeyHandler keyHandler in allLockedObjs)
        {
            keyHandler.removeKey();
        }
    }
}
