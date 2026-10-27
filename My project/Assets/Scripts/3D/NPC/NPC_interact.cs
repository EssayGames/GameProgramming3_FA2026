using JetBrains.Annotations;
using TMPro;
using Unity.Cinemachine;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using Yarn.Unity;


public enum i_type { npc, item}

public class NPC_interact : MonoBehaviour
{
    [Tooltip("Type of Interaction")]
    public i_type type;
    //The type not only determines the kind of object interaction
    //it will also modify the actual layout of inspector component
    //for full extandable/flexibility log determine what `type` needs to be implemented


    [System.Serializable]
    public struct TextData
    {
        public TextMeshProUGUI UIText;
        public string interactText;
    }

    [Header("Text Display Data")]
    public TextData textData;
    
    [System.Serializable]
    public struct InteractionYSData
    {
        public bool canInteract;
        public DialogueRunner npcDialogue;
        public NPC_Data npcData;

    }
    [Header("Collision, YarnSpinner, & NPC Data")]
    public InteractionYSData storyData;

    [System.Serializable]
    public struct CamData
    {
        public GameObject npcCam;
        public GameObject npcCamPrefab;
    }

    public CamData camData;

    public void setNpcCam()
    {
        camData.npcCam = transform.GetChild(0).gameObject;
    }

    public void loadNpcCam()
    {
        //need to add check to see if npcCamPrefab is already loaded
        Instantiate(camData.npcCamPrefab, transform);

    }

    public void loadTextObj()
    {
        textData.UIText = GameObject.FindGameObjectWithTag("iText").GetComponent<TextMeshProUGUI>();
    }

    public void loadYS()
    {
        storyData.npcDialogue = GameObject.FindGameObjectWithTag("dialogueRunner").GetComponent<DialogueRunner>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            setText(textData.interactText);
            storyData.canInteract = true;
        }
    }
    public void OnTriggerExit(Collider other)
    {
       if(other.gameObject.tag == "Player")
        {
            setText("");
            storyData.canInteract = false;
        }
    }

    public void setText (string txt)
    {
        textData.UIText.text = txt;
    }

    
    public void Update()
    {
        if (storyData.canInteract)
        {
            if (Keyboard.current.eKey.wasPressedThisFrame)
            {
                Debug.Log("Started Talking");
                setText("");
                storyData.npcDialogue.StartDialogue(storyData.npcData.dialogStart);
                //movePlayer puts the player in the correct position
                camData.npcCam.GetComponent<NPC_CAM>().movePlayer();
                storyData.canInteract = false;
            }
        }
    }

    [YarnCommand("setPhaseFromYarn")]
    public void setNPCPhase(string phase)
    {
        if(phase == "quest_taken")
        {
            storyData.npcData.selectPhase = NPC_Data.dialogPhase.quest_taken;
        }
    }

    [YarnCommand("setPhaseToYarn")]
    public void setYarnPhase()
    {
        InMemoryVariableStorage vStore = GameObject.FindAnyObjectByType<InMemoryVariableStorage>();
        vStore.SetValue("$dialogPhase", storyData.npcData.selectPhase.ToString());
    }

    public void OnApplicationQuit()
    {
        storyData.npcData.Reset();
    }
}
