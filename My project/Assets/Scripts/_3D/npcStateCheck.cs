using UnityEngine;

public class npcStateCheck : MonoBehaviour
{
    //the below method returns a string value
    //any method that doesn't use `void` can return a dataType value
    //we just have to make sure to use `return` of a dataType that shares the same type as the method
    //for example: we're making a string method, and then are returning a string varaible/value
    public string getState(pState playerState)
    {
        string currentPlayerState = "";
        //switch blocks are a type of logic that "replaces" the less-efficient `if/else if/else` technique
        //for every "check" we want to make we use the `case` keyword, and must also use a `break` for every case
        switch (playerState)
        {
            case pState.OK:
                //for this method, we are returning a string value that will eventually map to a YS node name
                currentPlayerState = "beginOK";
                break;

            case pState.hurt:
                currentPlayerState = "beginHurt";
                break;
        }
        return currentPlayerState;
    }
}
