using TMPro;
using UnityEngine;

public class WalletManager : MonoBehaviour
{
    public int startingCash;
    public TextMeshProUGUI walletDisplay;

    void Start()
    {
        walletDisplay.text = startingCash.ToString();
    }

    public void updateMoney(int value)
    {
        int currentCash = startingCash;
        currentCash += -value;
        startingCash = currentCash;
        walletDisplay.text = currentCash.ToString();
    }
}
