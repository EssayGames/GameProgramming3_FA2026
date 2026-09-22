using UnityEngine;
using UnityEngine.SceneManagement;

public class _HouseEnter : MonoBehaviour
{
    public Transform houseReturn;
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            _GameController.instance.loadLocationData(houseReturn.position, houseReturn.rotation);
            //GO TO THE `NEXT` SCENE
            SceneManager.LoadScene(1);
        }
    }
}
