using System;
using UnityEngine;

[Serializable]
public class items
{
    //to declare a varialbe we need three elements: [scope] [datatype] [customName]
    public string itemName;
    public Sprite icon;

    //To call this class with default values
    //I want to create a "constructor" that I can use
    //when I declare this class for the first time
    
    //When making a constructor DO NOT use void because the class
    //will interpret that as a function rather than a constructor
    public items()
    {
        itemName = "default item";
        icon = null;
    }

    public void assignIcon(Sprite newIcon)
    {
        icon = newIcon;
    }
}
