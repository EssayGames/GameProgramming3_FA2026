using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using Yarn.Unity;

public class NPC_Interact : MonoBehaviour
{
    //TODO: Get storyData to `set` the phase of our Yarn Spinner Scripts
    //TODO: Set storyData from Yarn Spinner Scripts
    

    public TextMeshProUGUI promtText;
    public string interactText;
    public bool canInteract;
    public DialogueRunner npcDialogue;
    public NPC_Cam_Rig npc_cam_rig;
    public npcData storyData;

    public void Start()
    {
        //Setting this variable looks a bit `static` for our system design tastes
        //BUT we can practice a bit of deliberate design because we know we're creating
        //a systematized NPC rig & interaction for multiple instances
        npc_cam_rig = transform.GetComponentInChildren<NPC_Cam_Rig>();
    }

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
                npc_cam_rig.movePlayer();
                npcDialogue.StartDialogue(storyData.startingNode);
                canInteract = false;
            }
        }
    }

    [YarnCommand("setPhase")]
    public void setStoryPhase()
    {
        InMemoryVariableStorage vStore = GameObject.FindAnyObjectByType<InMemoryVariableStorage>();
        vStore.SetValue("$dialogPhase", storyData.currentPhase.ToString());
    }
}
