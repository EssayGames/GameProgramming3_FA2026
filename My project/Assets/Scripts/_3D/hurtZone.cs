using UnityEngine;

public class hurtZone : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<playerStateMachine>().setState(pState.hurt);
        }
    }
}
