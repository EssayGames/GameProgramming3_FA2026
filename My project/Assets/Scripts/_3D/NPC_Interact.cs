using TMPro;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.InputSystem;
using Yarn.Unity;

public enum iType { npc, item}

public class NPC_Interact : MonoBehaviour
{
    [Tooltip("Select the type of Interaction to gain access to neccessary variables.")]
    public iType type;
    //TODO: Get storyData to `set` the phase of our Yarn Spinner Scripts
    //TODO: Set storyData from Yarn Spinner Scripts

    [System.Serializable]
    public struct TextData
    {
        public TextMeshProUGUI promtText;
        public string interactText;

    }
    [Header("Text Data Variables")]
    public TextData textData;

    public bool canInteract;

    [System.Serializable]
    public struct DialogueData
    {
        public DialogueRunner npcDialogue;
        public npcData storyData;
    }
    [Header("Story & YarnSpinner Variables")]
    public DialogueData dialogueData;

    [System.Serializable]
    public struct CamData
    {
        public GameObject npcCamPrefab;
        public NPC_Cam_Rig npc_cam_rig;
    }
    [Header("NPC Cam Rig Variables")]
    public CamData camData;

    public void Start()
    {
        //Setting this variable looks a bit `static` for our system design tastes
        //BUT we can practice a bit of deliberate design because we know we're creating
        //a systematized NPC rig & interaction for multiple instances
    }

    //-----EDITOR METHODS-----//

    public void loadText()
    {
        textData.promtText = GameObject.FindGameObjectWithTag("pText").GetComponent<TextMeshProUGUI>();
    }

    public void loadNpcCamPrefab()
    {
        Instantiate(camData.npcCamPrefab, transform);
        camData.npc_cam_rig = transform.GetComponentInChildren<NPC_Cam_Rig>();
    }

    public void loadYS()
    {
        dialogueData.npcDialogue = GameObject.FindGameObjectWithTag("dRunner").GetComponent<DialogueRunner>();
    }


    //-----RUNTIME METHOD-----//

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            setText(textData.interactText);
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
        textData.promtText.text = txt;
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
                camData.npc_cam_rig.movePlayer();
                dialogueData.npcDialogue.StartDialogue(dialogueData.storyData.startingNode);
                canInteract = false;
            }
        }
    }

    //This yarn command / method `sets` the $dialogPhase variable in my YarnSpinner script.
    //We use this in our `loadPhase` node to route the YarnSpinner script to it's correct story path.
    [YarnCommand("setPhase")]
    public void setStoryPhase()
    {
        InMemoryVariableStorage vStore = GameObject.FindAnyObjectByType<InMemoryVariableStorage>();
        vStore.SetValue("$dialogPhase", dialogueData.storyData.currentPhase.ToString());
    }

    //This yarn command / method `gets` a string from YarnSpinner and "converts" that to the phase we're on in our npcData scriableObject;
    //It also contains a nice lil' error reporting in case we pass a string that does not correspond to any dialogPhase.
    [YarnCommand("getPhase")]
    public void getStoryPhase(string phase)
    {
        if(phase == "comeback")
        {
            dialogueData.storyData.currentPhase = npcData.dialogPhase.comeback;
        }
        else if(phase == "quest_completed")
        {
            dialogueData.storyData.currentPhase = npcData.dialogPhase.quest_completed;
        }
        else
        {
            Debug.LogError("The string you passed in the Yarn Script does not match any current dialogPhase in the npcData scriptableObject");
        }
    }

    public void OnApplicationQuit()
    {
        dialogueData.storyData.dataReset();
    }
}
