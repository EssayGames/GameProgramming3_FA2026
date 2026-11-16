using UnityEngine;
using System.Collections;

[System.Serializable]
public class GameData
{
    public Vector3 playerPos;
    
    //this is the constructor of this class
    //we will use this when we make new instances of this class to store our data
    //BUT be mindful, that the default value will return Vector3(0,0,0)
    public GameData()
    {
        this.playerPos = Vector3.zero;
    }
}
