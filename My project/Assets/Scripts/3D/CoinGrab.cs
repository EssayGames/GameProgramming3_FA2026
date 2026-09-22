using UnityEngine;
using UnityEngine.Events;

public class CoinGrab : MonoBehaviour
{
    public string coinID;

    public void Awake()
    {
        coinID = this.name + "_" + transform.position.ToString();
    }

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
        GameController.instance.updateCoins(coinID);
        this.GetComponent<MeshRenderer>().enabled = false;
        this.GetComponent<SphereCollider>().enabled = false;
        this.GetComponent<MeshCollider>().enabled = false;
    }
}
