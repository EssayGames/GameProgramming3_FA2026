using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class WalletManager : MonoBehaviour
{
    public int startingCash;
    public TextMeshProUGUI walletDisplay;
    public UnityEvent returnItem;

    void Start()
    {
        walletDisplay.text = startingCash.ToString();
    }

    public void updateMoney(int value)
    {
        int currentCash = startingCash;
        currentCash += -value;
        if(currentCash < 0)
        {
            returnItem.Invoke();
        }
        else
        {
            startingCash = currentCash;
            walletDisplay.text = currentCash.ToString();
        }
        
    }
}
