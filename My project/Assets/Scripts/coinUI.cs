using TMPro;
using UnityEngine;

public class coinUI : MonoBehaviour
{
    public TextMeshProUGUI coinAmtText;

    public void addCoins(int coin)
    {
        coinAmtText.text = coin.ToString();
    }
}
