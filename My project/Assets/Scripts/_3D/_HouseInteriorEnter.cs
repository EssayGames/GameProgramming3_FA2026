using UnityEngine;

public class _HouseInteriorEnter : MonoBehaviour
{

    void Start()
    {
        _GameController.instance.SpawnThirdPersonPrefab(this.transform.position, this.transform.rotation);
    }

}
