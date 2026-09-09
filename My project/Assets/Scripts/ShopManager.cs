using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public List<potions_so> allPotions;
    public int shopAmt;
    public GameObject shopContainer;
    public TextMeshProUGUI textContainer;


    public void shopEnter()
    {
        for(int i = 0; i < shopAmt; i++)
        {
            //for every iteration of this loop, create a new GameObject
            //add an image and potionsData component to this new GameObject
            //the potionsData component is a separate class that will store our
            //postions_so Scriptable Object generated from our allPotions List
            GameObject newP = new GameObject();
            Image img = newP.AddComponent<Image>();
            potionsData newData = newP.AddComponent<potionsData>();

            //when we assign the potionsData class to our new GameObject
            //we can then load in the textContainer variable of *this* class
            //into the infoText variable of the *potionsData* class
            newData.infoText = textContainer;

            //after generating our random potion we then assign the data
            //and assign the parent of the newP GameObject to the shopContainer
            potions_so randP = allPotions[Random.Range(0, allPotions.Count)];
            newData.pData = randP;
            img.sprite = newData.pData.icon;
            newP.transform.SetParent(shopContainer.transform, false);
        }

    }

    //this method is called by the `Leave Button` On_Click ______
    public void shopLeave()
    {
        for(int i = 0; i < shopAmt; i++)
        {
            Destroy(shopContainer.transform.GetChild(i).gameObject);
        }

    }

}
