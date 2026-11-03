using TMPro;
using UnityEngine;

public class coinUI : MonoBehaviour
{
    public TextMeshProUGUI coinAmtText;

    public void Awake()
    {
        GameController.instance.setUI(this);
        addCoins(GameController.instance.currentCoins);
    }

    public void addCoins(int coin)
    {
        coinAmtText.text = coin.ToString();
    }
}
