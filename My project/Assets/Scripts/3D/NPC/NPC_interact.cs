using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using Yarn.Unity;

public class NPC_interact : MonoBehaviour
{
    public TextMeshProUGUI UIText;
    public string interactText;
    public bool canInteract = false;
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

    public void setText (string txt)
    {
        UIText.text = txt;
    }

    public void Update()
    {
        if (canInteract)
        {
            if (Keyboard.current.eKey.wasPressedThisFrame)
            {
                Debug.Log("Started Talking");
                setText("");
                npcDialogue.StartDialogue("Start");
                canInteract = false;
            }
        }
    }
}
