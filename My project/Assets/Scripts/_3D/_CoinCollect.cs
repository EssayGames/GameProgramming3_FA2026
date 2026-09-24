using UnityEngine;

public class _CoinCollect : MonoBehaviour
{
    public string coinID;

    public void Awake()
    {
        coinID = this.name + "_" + transform.position.ToString();
    }

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collider Name: " + other.gameObject.name);
        if(other.gameObject.tag == "Player")
        {
            collectedCoin();
            //Debug.Log(coinID);
        }
    }

    public void collectedCoin()
    {
        _GameController.instance.coinGot(coinID);
        this.GetComponent<MeshRenderer>().enabled = false;
        this.GetComponent<CapsuleCollider>().enabled = false;
        this.GetComponent<SphereCollider>().enabled = false;
    }


}
