using UnityEngine;

public enum pState { OK, hurt}

public class playerStateMachine : MonoBehaviour
{
    public pState playerState;

    //below is a setter method that takes an enum as an argument
    ///and sets the current state of the player
    public void setState(pState state)
    {
        playerState = state;
    }
}
