using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class MakePotions : MonoBehaviour
{
    public Button makeButton;
    public Potions p = new Potions();
    public List<Sprite> allPotionSprites;
    public GameObject potionContainer;

    public void Start()
    {
        makeButton = GetComponent<Button>();
        makeButton.onClick.Invoke();
    }

    public void createPotions()
    {
        p.icon = allPotionSprites[Random.Range(0, allPotionSprites.Count)];
        GameObject newPotion = new GameObject();
        Image img = newPotion.AddComponent<Image>();
        img.sprite = p.icon;
        newPotion.transform.SetParent(potionContainer.transform, false);
        newPotion.transform.localScale = new Vector3(1, 1, 1);

    }
}
