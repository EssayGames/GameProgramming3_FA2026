using UnityEngine;

public class keyPickup : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            keyInvetoryManager.instance.collectedKey();
            toggleObj(false);
        }
    }

    public void toggleObj(bool state)
    {
        GetComponent<MeshRenderer>().enabled = state;
        GetComponent<MeshCollider>().enabled = state;
        GetComponent<SphereCollider>().enabled = state;
    }
}
