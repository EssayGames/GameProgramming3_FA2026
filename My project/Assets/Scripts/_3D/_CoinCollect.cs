using UnityEngine;

public class _CoinCollect : MonoBehaviour
{
    //TODO: Reference the GameController Singleton

   public void Start() { 
    }
   public void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collider Name: " + other.gameObject.name);
        if(other.gameObject.tag == "Player")
        {
            collectedCoin();
        }
    }

    public void collectedCoin()
    {
        _GameController.instance.coinGot();
        this.GetComponent<MeshRenderer>().enabled = false;
        this.GetComponent<CapsuleCollider>().enabled = false;
        this.GetComponent<SphereCollider>().enabled = false;
    }


}
