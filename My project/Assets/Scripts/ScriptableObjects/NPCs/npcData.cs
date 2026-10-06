using UnityEngine;

[CreateAssetMenu(fileName = "npcData", menuName = "NPC Profile")]
public class npcData : ScriptableObject
{
    public string npcName;
    public string startingNode;
    public enum dialogPhase { comeback, begin, quest_started, quest_completed, reward_given, }
    public dialogPhase currentPhase;

    public void dataReset()
    {
        currentPhase = dialogPhase.begin;
    }
}
