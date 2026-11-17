using UnityEngine;
using System.Collections;

[System.Serializable]
public class GameData
{
    public Vector3 playerPos;

    //this is the constructor of this class
    //we will call this from our dataManager singleton, it has a Vector3(0,0,0) default value
    public GameData()
    {
        this.playerPos = Vector3.zero;
    }
}
