using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class lockedObj : MonoBehaviour, iKeyHandler
{
    public bool canBeUnlocked;
    public bool canInteract;
    public TextMeshProUGUI interactText;

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
                setText("Press E to unlock");
                canInteract = true;
            }
            else
            {
                setText("Requires a Key");
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
        interactText.text = txt;
    }

    public void Update()
    {
        if(canInteract)
        {
            if (Keyboard.current.eKey.wasPressedThisFrame)
            {
                setText("");
                InventoryManager.instance.usedKey();
                canInteract = false;
                Debug.Log("unlocked");
            }
        }
    }

}
