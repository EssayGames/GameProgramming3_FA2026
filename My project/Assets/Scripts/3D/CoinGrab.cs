using UnityEngine;
using UnityEngine.Events;

public class CoinGrab : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        if(other.gameObject.tag == "Player")
        {
            collectCoin();
        }
    }

    public void collectCoin()
    {
        GameController.instance.updateCoins();
        this.GetComponent<MeshRenderer>().enabled = false;
        this.GetComponent<SphereCollider>().enabled = false;
        this.GetComponent<MeshCollider>().enabled = false;
    }
}
