using UnityEngine;

public class checkPoint : MonoBehaviour, IDataHandler
{
    public Transform saveLoc;
    public bool gotCheckpoint = false;

    public void LoadData(GameData data)
    {
        // no need for loading Data for this interface
    }

    public void SaveData(ref GameData data)
    {
        if (gotCheckpoint)
        {
            data.playerPos = saveLoc.position;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            gotCheckpoint = true;
        }
    }

}
