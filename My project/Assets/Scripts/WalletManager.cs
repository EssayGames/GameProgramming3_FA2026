using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class WalletManager : MonoBehaviour
{
    public TextMeshProUGUI cashText;
    public int cash;
    public UnityEvent returnItem;

    public void Start()
    {
        cashText.text = cash.ToString();
    }

    public void updateCash(int value)
    {
        int currentCash = cash;
        currentCash += -value;
        if (currentCash < 0)
        {
            returnItem.Invoke();
        }
        else
        {
            cash = currentCash;
            cashText.text = cash.ToString();
        }
    }
}
