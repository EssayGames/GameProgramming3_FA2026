using UnityEngine;

public class house_load : MonoBehaviour
{
    public Transform loadLoc;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameController.instance.loadFPS(loadLoc.position, loadLoc.rotation);
    }

}
