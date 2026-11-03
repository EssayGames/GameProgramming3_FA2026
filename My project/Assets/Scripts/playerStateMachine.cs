using UnityEngine;

public enum pState { OK, hurt}

public class playerStateMachine : MonoBehaviour
{
    public pState state;

    //this is a setter method for our `state` variable in this class
    //the `state` variable is an enum that we can toggle between different "states"
    public void setState(pState newState)
    {
        state = newState;
    }
}
