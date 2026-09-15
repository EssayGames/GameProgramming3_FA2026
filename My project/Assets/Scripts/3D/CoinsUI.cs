using TMPro;
using UnityEngine;

public class CoinsUI : MonoBehaviour
{
    public TextMeshProUGUI coinsAmt;
    public int currentCoins;

    public void addCoins()
    {
        currentCoins++;
        coinsAmt.text = currentCoins.ToString();
    }
}
