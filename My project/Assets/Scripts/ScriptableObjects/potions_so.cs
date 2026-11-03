using UnityEngine;

[CreateAssetMenu(fileName = "potions_so", menuName = "Potion")]
public class potions_so : ScriptableObject
{
    public string description;
    public Sprite icon;
    public int cost;
    public string pName;
}
