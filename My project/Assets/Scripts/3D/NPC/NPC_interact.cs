using JetBrains.Annotations;
using TMPro;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;
using Yarn.Unity;


public class NPC_interact : MonoBehaviour
{
    public TextMeshProUGUI UIText;
    public string interactText;
    public bool canInteract = false;
    public DialogueRunner npcDialogue;
    public GameObject npcCam;
    public NPC_Data npcData;

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
                npcDialogue.StartDialogue(npcData.dialogStart);
                //movePlayer puts the player in the correct position
                npcCam.GetComponent<NPC_CAM>().movePlayer();
                canInteract = false;
            }
        }
    }

    [YarnCommand("setPhaseFromYarn")]
    public void setNPCPhase(string phase)
    {
        if(phase == "quest_taken")
        {
            npcData.selectPhase = NPC_Data.dialogPhase.quest_taken;
        }
    }

    [YarnCommand("setPhaseToYarn")]
    public void setYarnPhase()
    {
        InMemoryVariableStorage vStore = GameObject.FindAnyObjectByType<InMemoryVariableStorage>();
        vStore.SetValue("$dialogPhase", npcData.selectPhase.ToString());
    }

    public void OnApplicationQuit()
    {
        npcData.Reset();
    }
}
