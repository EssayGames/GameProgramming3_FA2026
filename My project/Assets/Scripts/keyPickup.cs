using UnityEngine;

public class keyPickup : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            keyInvetoryManager.instance.collectedKey();
        }
    }
}
