using UnityEngine;
using UnityEngine.SceneManagement;

public class house_enter : MonoBehaviour
{
    public Transform entry;
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            GameController.instance.setSpawnPoint(entry.position, entry.rotation);
            SceneManager.LoadScene(1);
        }
    }
}
