    using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;


public class PillarInteract : MonoBehaviour
{
    public UnityEvent buttonPush;

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            buttonPush.Invoke();
        }
    }
}
