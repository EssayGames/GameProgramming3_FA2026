using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using Yarn.Unity;

public enum interactType { npc, item}

public class NPC_Interact : MonoBehaviour
{
    public interactType type;
    [System.Serializable]
    public struct TextData
    {
        public TextMeshProUGUI interactText;
        public string interaction;
    }
    public TextData textData;

    public bool canInteract;

    [System.Serializable]
    public struct CamData
    {
        public NPC_Cam_Control camController;
        public GameObject npcCamPrefab;
    }

    public CamData camData;

    [System.Serializable]
    public struct storyData
    {
        public DialogueRunner dialogue;
        public NPC_Data npcData;
        public NPC_StateCheck stateCheck;
    }

    public storyData dialogVars;

    public void Start()
    {
        //this behavior is a bit `static` compared to previous system design techniques
        //BUT we are making this more `hard-coded` in an attempt to standardize our NPC_Cam_Rig system
        camData.camController = transform.GetComponentInChildren<NPC_Cam_Control>();
    }

    //----- EDITOR METHODS ------//

    public void setTextVars()
    {
        textData.interactText = GameObject.FindGameObjectWithTag("pText").GetComponent<TextMeshProUGUI>();
    }

    public void loadNpcCamPrefab()
    {
        Instantiate(camData.npcCamPrefab, transform);
    }

    public void setNpcCam()
    {
        camData.camController = transform.GetComponentInChildren<NPC_Cam_Control>();
    }

    public void setYS()
    {
        dialogVars.dialogue = GameObject.FindGameObjectWithTag("dRunner").GetComponent<DialogueRunner>();
        dialogVars.stateCheck = gameObject.GetComponent<NPC_StateCheck>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            setText(textData.interaction);
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
        textData.interactText.text = txt;
    }

    public void Update()
    {
        if (canInteract)
        {
            if (Keyboard.current.eKey.wasPressedThisFrame)
            {
                Debug.Log("You Talked to the NPC!");
                setText("");
                _pState state = GameObject.FindGameObjectWithTag("Player").GetComponent<playerState>().state;
                camData.camController.movePlayer();
                //old way of starting dialog
                //dialogVars.dialogue.StartDialogue(dialogVars.npcData.startingNode);
                dialogVars.dialogue.StartDialogue(dialogVars.stateCheck.getState(state));
                canInteract = false;
            }
        }
    }

    //this is the `set` of the current phase of our YS dialog pulled from our npcData variable
    [YarnCommand("dialogPhaseSetter")]
    public void setYarnPhase()
    {
        InMemoryVariableStorage vData = GameObject.FindAnyObjectByType<InMemoryVariableStorage>();
        vData.SetValue("$dialogPhase", dialogVars.npcData.currentPhase.ToString());
    }

    //this is the `get` of the current phase MADE in our YS dialog based on what options we've selected.
    [YarnCommand("dialogPhaseGetter")]
    public void getYarnPhase(string phase)
    {
        if(phase == "quest_taken")
        {
            dialogVars.npcData.currentPhase = NPC_Data.dialogPhase.quest_taken;
        }
        if(phase == "quest_complete_return")
        {
            dialogVars.npcData.currentPhase = NPC_Data.dialogPhase.quest_complete_return;
        }
    }

    public void OnApplicationQuit()
    {
        dialogVars.npcData.resetData();
    }
}
