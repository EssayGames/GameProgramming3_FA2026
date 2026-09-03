using UnityEngine;
using UnityEngine.EventSystems;

public class Inventroy : MonoBehaviour, IDropHandler
{
    public WalletManager wallet;
    public void OnDrop(PointerEventData eventData)
    {
        GameObject droppedItem = eventData.pointerDrag;
        shopItemData droppedData = droppedItem.GetComponent<shopItemData>();
        droppedData.lastPos = transform;
        wallet.updateMoney(droppedData.pData.price);
    }
}
