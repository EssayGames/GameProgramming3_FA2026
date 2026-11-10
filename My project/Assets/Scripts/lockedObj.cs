using TMPro;
using UnityEngine;

public class lockedObj : MonoBehaviour, iKeyHandler
{
    public bool canBeUnlocked;
    public bool canInteract;
    public TextMeshProUGUI interactPrompt;

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
                setText("Requires a Key to Unlock");
            }
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            setText("");
            canInteract = false;
        }

    }

    public void setText(string txt)
    {
        interactPrompt.text = txt;
    }
}
