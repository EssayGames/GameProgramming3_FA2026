using TMPro;
using UnityEngine;

public class lockedObj : MonoBehaviour, iKeyHandler
{
    //FINISHED: Create bool for checking if we can unlock this object
    //FINISHED: Implement the interface to check to see if the player has a key to use
    //FINISHED: Creating a trigger to prompt the player and activate the interaction
    
    //TODO: Implement the interface to remove a key from the player when we unlock the obj

    public bool canInteract;
    public bool canBeUnlocked;
    public TextMeshProUGUI promptText;

    public void canUnlock()
    {
        canBeUnlocked = true;
    }
    public void removeKey()
    {
        canBeUnlocked = false;
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if (canBeUnlocked)
            {
                setText("Press E to Unlock");
                canInteract = true;
            }
            else
            {
                setText("Need Key to Unlock");
            }
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            setText("");
        }
    }


    public void setText(string txt)
    {
        promptText.text = txt;
    }
}
