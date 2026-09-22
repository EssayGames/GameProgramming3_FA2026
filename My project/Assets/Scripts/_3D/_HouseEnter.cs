using UnityEngine;
using UnityEngine.SceneManagement;

public class _HouseEnter : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            //GO TO THE `NEXT` SCENE
            SceneManager.LoadScene(1);
        }
    }
}
