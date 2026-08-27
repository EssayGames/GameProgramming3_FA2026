using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class genItems : MonoBehaviour
{
    public items newItem = new items();
    public Button genBtn;
    public GameObject itemContainer;
    public List<Sprite> randIcons;

    private void Start()
    {
        Debug.Log("NewItem name: " + newItem.itemName);
        genBtn = GetComponent<Button>();

    }

    public void generateIcon()
    {
        GameObject generatedIcon = new GameObject();
        Image img = generatedIcon.AddComponent<Image>();
        newItem.assignIcon(randIcons[Random.Range(0, randIcons.Count)]);
        img.sprite = newItem.icon;
        generatedIcon.transform.SetParent(itemContainer.transform, false);
    }


}
