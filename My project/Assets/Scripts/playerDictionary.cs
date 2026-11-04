using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class playerDictionary : MonoBehaviour
{
    public Dictionary<int, gameObj_items> items = new Dictionary<int, gameObj_items>();

    public void addItems(gameObj_items value)
    {
        int key = items.Count;
        items.Add(key, value);
    }

    public bool hasItems(List<gameObj_items> allToCheck)
    {
        bool gotAllItems = false;
        foreach(int i in items.Keys)
        {
            if (allToCheck.Contains(items[i]))
            {
                gotAllItems = true;
            }
            else
            {
                gotAllItems = false;
                break;
            }
        }

        return gotAllItems;
        //return allItems.All(item => items.ContainsKey(item));
    }
}
