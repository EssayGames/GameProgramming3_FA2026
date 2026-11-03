using UnityEngine;

public enum _pState { OK, hurt}

public class playerState : MonoBehaviour
{
    public _pState state;

    public void setState(_pState newState)
    {
        state = newState;
    }
}
