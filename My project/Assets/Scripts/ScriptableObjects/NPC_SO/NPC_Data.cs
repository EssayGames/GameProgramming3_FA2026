using UnityEngine;
using Yarn.Unity;

[CreateAssetMenu(fileName = "NPC_Data", menuName = "NPC_Data")]
public class NPC_Data : ScriptableObject
{
    public string dialogStart;
    public enum dialogPhase { start, quest_taken, quest_complete, reward_given, repeat}
    public dialogPhase currentPhase;

    public void resetData()
    {
        currentPhase = dialogPhase.start;
    }

}
