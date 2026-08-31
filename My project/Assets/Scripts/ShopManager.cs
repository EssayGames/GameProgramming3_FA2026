using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine.UI;
using TMPro;

public class ShopManager : MonoBehaviour
{
    public List<Potions_so> allPotions;
    public int shopAmt;
    public GameObject shopContainer;
    public GameObject infoContainer;
    public Button enterBtn;
    public Button leaveBtn;

    public void enterShop()
    {
        for(int i = 0; i < shopAmt; i++)
        {
            GameObject newPotion = new GameObject();
            Image pImg = newPotion.AddComponent<Image>();
            shopItemData newData = newPotion.AddComponent<shopItemData>();
            newData.pData = allPotions[Random.Range(0, allPotions.Count)];
            newData.infoText = infoContainer.GetComponent<TextMeshProUGUI>();
            pImg.sprite = newData.pData.icon;
            newPotion.transform.SetParent(shopContainer.transform, false);
        }
        enterBtn.interactable = false;
        leaveBtn.interactable = true;
    }

    public void leaveShop()
    {
        if (shopContainer.transform.childCount != 0)
        {
            for (int i = 0; i < shopContainer.transform.childCount; i++)
            {
                Destroy(shopContainer.transform.GetChild(i).gameObject);
            }
        }

        enterBtn.interactable = true;
        leaveBtn.interactable = false;
    }
}
