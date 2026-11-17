using UnityEngine;

public class checkPoint : MonoBehaviour, IDataHandler
{
    public bool gotCheckPoint = false;
    public Transform saveLoc;

    public void LoadData(GameData data)
    {
        // No Data Needs to be load at this time
    }

    public void SaveData(ref GameData data)
    {
        if (gotCheckPoint)
        {
            data.playerPos = saveLoc.position;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            gotCheckPoint = true;
        }
    }
}
