using UnityEngine;

public class uniqueTreasureChest : MonoBehaviour, iKeyHandler
{
    public void canUnlock()
    {
        Debug.Log("Unique Treasure Chest Still Requires more Keys");
    }

    public void removeKey()
    {
        Debug.Log("Unique Treasure Chest needs at least one key to open");   
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
