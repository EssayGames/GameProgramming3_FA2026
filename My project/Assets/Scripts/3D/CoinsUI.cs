using TMPro;
using UnityEngine;

public class CoinsUI : MonoBehaviour
{
    public TextMeshProUGUI coinsAmt;
    
    public void Awake()
    {
        _GameController.instance.loadCoinUI(this);
    }

    public void addCoins(int coins)
    { 
        coinsAmt.text = coins.ToString();
    }
}
