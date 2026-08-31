using UnityEngine;
using UnityEngine.EventSystems;

public class Inventroy : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        GameObject droppedItem = eventData.pointerDrag;
        droppedItem.GetComponent<shopItemData>().lastPos = transform;
    }
}
