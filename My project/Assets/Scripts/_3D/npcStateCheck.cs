using UnityEngine;

public class npcStateCheck : MonoBehaviour
{
    //the below method uses a `string` as the return value
    //all methods can use a data type, but they MUST have a `return` keyword
    //when this method is called, it will then return the `currentPlayerState` string value
    public string checkState(pState playerState)
    {
        string currentPlayerState = "";

        //`switch` is a type of logic that easily replaces if/else if/else blocks
        //we use `case` to see if the argument in the switch is met
        //all `cases` must include a `break` in order for the switch to operate as intended
        switch (playerState)
        {
            case pState.OK:
                //in this particular switch, we want to return a string value
                //that will be passed into our Dialog Runner (Yarn Spinner) class
                currentPlayerState = "beginOK";
                break;

            case pState.hurt:
                currentPlayerState = "beginHurt";
                break;
        }

        return currentPlayerState;
    }
}
