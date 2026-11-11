using UnityEngine;

public class uniqueChest : MonoBehaviour, iKeyHandler
{
    public void canUnlock()
    {
        Debug.Log("The Unique Chest needs another key");
    }

    public void removeKey()
    {
        Debug.Log("The Unique Chest needs 2 keys to open");
    }

}
