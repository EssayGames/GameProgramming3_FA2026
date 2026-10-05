using UnityEngine;

[CreateAssetMenu(fileName = "NPC_Data", menuName = "NPC_Data")]
public class NPC_Data : ScriptableObject
{
    public string npcName;
    public string startingNode;
    public enum dialogPhase { start, repeat, quest_taken, quest_complete, quest_complete_return }
    public dialogPhase currentPhase;

    public void resetData()
    {
        currentPhase = dialogPhase.start;
    }
}
