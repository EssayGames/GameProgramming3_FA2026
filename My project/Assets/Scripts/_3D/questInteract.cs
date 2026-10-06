using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class questInteract : MonoBehaviour
{
    //FINISHED: Implement a trigger that prompts the player to interact
    
    //TODO: Set the storyData phase for my YarnSpinner script to interpret
    //TODO: Read input from my player to initialize the interaction

    public TextMeshProUGUI interactText;
    public bool canInteract;
    public updateDialogPhase changePhase;

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
        if(other.gameObject.tag == "Player")
        {
            setText("");
            canInteract = false;
        }
    }

    public void setText(string txt)
    {
        //set the text of a text mesh pro variable to the txt argument of this method
        interactText.text = txt;
    }

    public void Update()
    {
        if (canInteract)
        {
            if (Keyboard.current.eKey.wasPressedThisFrame)
            {
                changePhase.Invoke("quest_completed");
                canInteract = false;
            }
        }
    }
}

[System.Serializable]
public class updateDialogPhase : UnityEvent<string>
{

}
