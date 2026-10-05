using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class boxes_Interact : MonoBehaviour
{
    //FINISHED: When we collide prompt the player to interact with the boxes
    //FINISHED: Check collision of sphere collider to enable interaction
    
    //TODO: Destroy boxes once you "got" the items
    //TODO: Call the Dialog Runner to initiate a node for interaction
    //TODO: Load the NPC_Interact class to activate the next phase of the `quest`

    public bool canInteract;
    public TextMeshProUGUI interactText;
    public NPC_Interact npcI;

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            setText("Press E");
            canInteract = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            setText("");
            canInteract = false;
        }
    }

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
                npcI.npcData.currentPhase = NPC_Data.dialogPhase.quest_complete;
                canInteract = false;
            }
        }
    }
}
