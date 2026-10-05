using Unity.Cinemachine;
using UnityEngine;
using Yarn.Unity;

public class NPC_CAM : MonoBehaviour
{
    public CinemachineCamera npc_cam;
    public Transform npc_view;
    public Transform pc_view;
    public Transform talking_spot;


    [YarnCommand("cam_move")]
    public void cam_move(string cam_pos)
    {
        if (cam_pos == "npc")
        {
            npc_cam.Priority = 15;
            npc_cam.gameObject.transform.position = npc_view.position;
        }
        else if (cam_pos == "pc")
        {
            npc_cam.gameObject.transform.position = pc_view.position;
        }
        else if (cam_pos == "return")
        {
            npc_cam.Priority = 0;
        }
    }


    //Put this method here to organize talking_spot transform with this NPC_CAM functionality
    public void movePlayer()
    {
        GameController.instance.moveForDialog(talking_spot);
    }
}
