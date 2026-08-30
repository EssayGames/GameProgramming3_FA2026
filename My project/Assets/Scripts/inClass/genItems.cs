using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class genItems : MonoBehaviour
{
    //calling the contructor of the items class when I am declaring it as a variable
    //the constructor loads in the default values of the `items` class
    public items newItem = new items();
    public GameObject itemContainer;
    public List<Sprite> allIcons;

    public void generateItems()
    {
        GameObject newGenItem = new GameObject();
        Image img = newGenItem.AddComponent<Image>();
        newItem.assignIcon(allIcons[Random.Range(0, allIcons.Count)]);
        img.sprite = newItem.icon;
        newGenItem.transform.SetParent(itemContainer.transform, false);
    }

}
