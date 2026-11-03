using UnityEngine;
using UnityEngine.SceneManagement;

public class houseEnter : MonoBehaviour
{
    public Transform houseReturn;
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            GameController.instance.setSpawnPoint(houseReturn.position, houseReturn.rotation);
            SceneManager.LoadScene(1);
        }

        
    }
}
