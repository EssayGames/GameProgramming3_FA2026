using Unity.Cinemachine;
using UnityEngine;
using Yarn.Unity;

public class NPC_Cam_Control : MonoBehaviour
{
    //FINISHED: Switch from the TPC camera to the NPC_cCam camera (modify the `priority` attribute)
    //FINISHED: Create Methods for switching the NPC_cCam transform.position
    //FINISHED: Get the switching transform.position method to `talk` to YarnSpinner

    //TODO: Reposition the TPC `into frame` (so that we don't look weird)

    public Transform npc_loc;
    public Transform pc_loc;
    public Transform pc_move_loc;
    public CinemachineCamera npc_cCam;
    public int pValue;

    //need additional transform variable for where we want the player character to move to

    [YarnCommand("cam_move")]
    public void cam_move(string focus)
    {
        npc_cCam.Priority = pValue;
        if(focus == "npc")
        {
            npc_cCam.gameObject.transform.position = npc_loc.position;
        }
        else if(focus == "pc")
        {
            npc_cCam.gameObject.transform.position = pc_loc.position;
        }
        else if(focus == "return")
        {
            npc_cCam.Priority = 0;
        }
    }

    public void movePlayer()
    {
        GameController.instance.moveForDialog(pc_move_loc);
    }
}
