using System;
using UnityEngine;

[Serializable]
public class items 
{
    public string itemName;
    public Sprite icon;

    //in order to load this class with default values
    //I need to create a "constructor"
    //That constructor will be called when I use this class as a variable

    public items()
    {
        this.itemName = "default";
        this.icon = null;
    }

    public void assignIcon(Sprite newIcon)
    {
        this.icon = newIcon;
    }
}
