using UnityEngine;

public class keyPickup : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        keyInventoryManager.instance.collectedKey();
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<SphereCollider>().enabled = false;
        GetComponent<MeshCollider>().enabled = false;
    }
}
