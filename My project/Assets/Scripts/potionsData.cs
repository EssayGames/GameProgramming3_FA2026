using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class potionsData : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public potions_so pData;
    public TextMeshProUGUI infoText;
    public Transform lastPos;

    public void OnBeginDrag(PointerEventData eventData)
    {
        lastPos = this.transform.parent;
        transform.SetParent(lastPos.root);
        transform.SetAsLastSibling();
        this.GetComponent<Image>().raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Mouse.current.position.ReadValue();
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.position = lastPos.position;
        transform.SetParent(lastPos);
        this.GetComponent<Image>().raycastTarget = true;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        infoText.text = pData.description;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        infoText.text = "";
    }
}
