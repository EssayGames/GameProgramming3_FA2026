using UnityEngine;

[CreateAssetMenu(fileName = "Potions_so", menuName = "Potions")]
public class Potions_so : ScriptableObject
{
    public string pName;
    public string description;
    public Sprite icon;
    public int price;
}
