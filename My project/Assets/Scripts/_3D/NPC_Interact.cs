using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using Yarn.Unity;

public class NPC_Interact : MonoBehaviour
{
    //TODO: Prompt the player to interact
    //TODO: Read the interact button to start dialog
    //TODO: Lock player movement
    //TODO: Lock Camera movement
    //TODO: Read the Yarn Script and activate the desired Node
    //TODO: UNDO EVERYTHING

    public TextMeshProUGUI promtText;
    public string interactText;
    public bool canInteract;
    public DialogueRunner npcDialogue;

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            setText(interactText);
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

    public void setText(string txt)
    {
        promtText.text = txt;
    }

    // Update is called once per frame
    void Update()
    {
        if (canInteract)
        {
            if (Keyboard.current.eKey.wasPressedThisFrame)
            {
                Debug.Log("Start NPC Dialogue");
                setText("");
                npcDialogue.StartDialogue("Start");
                canInteract = false;
            }
        }
    }
}
