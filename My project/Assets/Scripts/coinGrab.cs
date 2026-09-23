using UnityEngine;

public class coinGrab : MonoBehaviour
{
    //this coinID string allows us to have our GameController identify each individual `instance` of our prefab
    public string coinID;

    public void Awake()
    {
        coinID = this.name + "_" + transform.position.ToString();
    }

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
        GameController.instance.coinCollect(coinID);
        this.GetComponent<MeshRenderer>().enabled = false;
        this.GetComponent<CapsuleCollider>().enabled = false;
        this.GetComponent<SphereCollider>().enabled = false;

    }
}
