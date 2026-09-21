using UnityEngine;

public class coinGrab : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collided Object: " + other.gameObject.name);
        if(other.gameObject.tag == "Player")
        {
            coinGot();
        }
    }

    public void coinGot()
    {
        GameController.instance.coinCollect();
        this.GetComponent<MeshRenderer>().enabled = false;
        this.GetComponent<CapsuleCollider>().enabled = false;
        this.GetComponent<SphereCollider>().enabled = false;

    }
}
