using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class potionsData : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public potions_so pData;
    public TextMeshProUGUI infoText;

    public void OnPointerEnter(PointerEventData eventData)
    {
        infoText.text = pData.description;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        infoText.text = "";
    }
}
