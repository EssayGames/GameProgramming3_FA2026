using UnityEngine;
using System.Collections.Generic;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance {  get; private set; }
    public List<iKeyHandler> allLockedObjs = new List<iKeyHandler>();

    public void Awake()
    {
        if (instance != null && instance != this)
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
        refreshLockedObjList();
    }

    public void refreshLockedObjList()
    {
        MonoBehaviour[] allScripts = FindObjectsByType<MonoBehaviour>();
        for (int i = 0;i <allScripts.Length; i++) 
        { 
            if (allScripts[i] is iKeyHandler)
            {
                allLockedObjs.Add(allScripts[i] as iKeyHandler);
            }
        
        }

    }


    public void collectedKey()
    {
        foreach(iKeyHandler keyHandler in allLockedObjs)
        {
            keyHandler.canUnlock();
        }
    }

    public void usedKey()
    {
        foreach(iKeyHandler keyHandler in allLockedObjs)
        {
            keyHandler.removeKey();
        }
    }
}
