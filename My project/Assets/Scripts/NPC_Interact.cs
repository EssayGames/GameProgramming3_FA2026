using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using Yarn.Unity;

public class NPC_Interact : MonoBehaviour
{
    //FINISHED: Check to see if the player is in the trigger radius
    //FINISHED: Activate the interaction text
    //FINISHED: Check if the player is in the trigger when they press the interaction key
    //FINISHED: Activate Yarn Spinner -- or our DialogRunner
    //FINISHED: Checking Player Controller for movement
    //FINISHED: Player movement is disabled

    //PARTIALLY FINISHED: `limit` (and eventually control) camera movement

    public TextMeshProUGUI interactText;
    public string interaction;
    public bool canInteract;
    public DialogueRunner dialogue;

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            setText(interaction);
            canInteract = true;
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

    //this is the setter method for our interact text
    public void setText(string txt)
    {
        interactText.text = txt;
    }

    public void Update()
    {
        if (canInteract)
        {
            if (Keyboard.current.eKey.wasPressedThisFrame)
            {
                Debug.Log("You Talked to the NPC!");
                setText("");
                dialogue.StartDialogue("Start");
                canInteract = false;
            }
        }
    }
}
