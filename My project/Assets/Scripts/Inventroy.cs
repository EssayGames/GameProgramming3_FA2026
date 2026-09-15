using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Inventroy : MonoBehaviour, IDropHandler
{
    public cashCheck purchase;
    public WalletManager wallet;
    public GameObject droppedItem;
    public shopItemData droppedData;
    public Transform shopContainer;
    public void OnDrop(PointerEventData eventData)
    {
        droppedItem = eventData.pointerDrag;
        droppedData = droppedItem.GetComponent<shopItemData>();
        droppedData.lastPos = transform;

        //purchase is a UnityEvent that takes an int argument
        //when invoked we transmite the price of pData
        purchase.Invoke(droppedData.pData.price);


        //wallet.updateMoney(droppedData.pData.price);
    }

    public void noMoney()
    {
        droppedData.lastPos = shopContainer;
    }
}


[System.Serializable]
public class cashCheck : UnityEvent<int>
{

}