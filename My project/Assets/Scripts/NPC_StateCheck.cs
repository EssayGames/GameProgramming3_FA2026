using UnityEditor;
using UnityEngine;

public class NPC_StateCheck : MonoBehaviour
{

    public string getState(_pState playerState)
    {
        string currentPlayerState = "";
        switch (playerState)
        {
            case _pState.OK:
                currentPlayerState = "startingOK";
                break;
            case _pState.hurt:
                currentPlayerState = "startingHurt";
                break;
            default:
                currentPlayerState = "noData";
                break;
        }

        return currentPlayerState;
    }

}
