using UnityEngine;
using UnityEngine.SceneManagement;

public class house_leave : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(0);
        }
    }
}
