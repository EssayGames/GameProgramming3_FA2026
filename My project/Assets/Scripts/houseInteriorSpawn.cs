using UnityEngine;

public class houseInteriorSpawn : MonoBehaviour
{ 
    void Start()
    {
        GameController.instance.SpawnCharacter(this.transform.position, this.transform.rotation);
    }

    
}
