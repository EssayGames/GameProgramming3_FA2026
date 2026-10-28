using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using Yarn.Unity;

public enum iType { npc, item }

public class _NPC_Interact : MonoBehaviour
{
    //TODO: Get storyData to `set` the phase of our Yarn Spinner Scripts
    //TODO: Set storyData from Yarn Spinner Scripts

    [Tooltip("Set the type of interaction to load the correct variables.")]
    public iType type;

    //We changed our variables to be grouped within `struct`s for visual clarity
    //and also to be able to call those groupings a little easier in our custom editor script
    [System.Serializable]
    public struct TextData
    {
        public TextMeshProUGUI promtText;
        public string interactText;
    }

    [Header("Text Display Variables")]
    public TextData textData;

    public bool canInteract;

    [System.Serializable]
    public struct CamData
    {
        public GameObject npcCamPrefab;
        public NPC_Cam_Control npc_cam_rig;

    }
    [Header("Camera Variables")]
    public CamData camData;

    [System.Serializable]
    public struct dialogData
    {
        public DialogueRunner npcDialogue;
        public NPC_Data storyData;

    }
    [Header("Dialog & NPC Data Variables")]
    public dialogData dialogVars;

    public void Start()
    {
        //Setting this variable looks a bit `static` for our system design tastes
        //BUT we can practice a bit of deliberate design because we know we're creating
        //a systematized NPC rig & interaction for multiple instances
        
        //npc_cam_rig = transform.GetComponentInChildren<NPC_Cam_Rig>();
    }

    //----EDITOR FUNCTIONS START----//

    public void setTextVars()
    {
        textData.promtText = GameObject.FindGameObjectWithTag("pText").GetComponent<TextMeshProUGUI>();
    }

    public void loadNpcCamPrefab()
    {
        Instantiate(camData.npcCamPrefab, transform);
    }

    public void setNpcCam()
    {
        camData.npc_cam_rig = transform.GetComponentInChildren<NPC_Cam_Control>();
    }

    public void setYS()
    {
        dialogVars.npcDialogue = GameObject.FindGameObjectWithTag("dRunner").GetComponent<DialogueRunner>();
    }

    //----EDITOR FUNCTIONS COMPLETE----//

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
                dialogVars.npcDialogue.StartDialogue(dialogVars.storyData.startingNode);
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
        vStore.SetValue("$dialogPhase", dialogVars.storyData.currentPhase.ToString());
    }

    //This yarn command / method `gets` a string from YarnSpinner and "converts" that to the phase we're on in our npcData scriableObject;
    //It also contains a nice lil' error reporting in case we pass a string that does not correspond to any dialogPhase.
    [YarnCommand("getPhase")]
    public void getStoryPhase(string phase)
    {
        if(phase == "comeback")
        {
            dialogVars.storyData.currentPhase = NPC_Data.dialogPhase.repeat;
        }
        else if(phase == "quest_completed")
        {
            dialogVars.storyData.currentPhase = NPC_Data.dialogPhase.quest_complete;
        }
        else
        {
            Debug.LogError("The string you passed in the Yarn Script does not match any current dialogPhase in the npcData scriptableObject");
        }
    }

    public void OnApplicationQuit()
    {
        dialogVars.storyData.resetData();
    }
}
