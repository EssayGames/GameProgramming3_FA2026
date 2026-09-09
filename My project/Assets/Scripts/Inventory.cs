using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class Inventory : MonoBehaviour, IDropHandler
{
    public cashSend purchase;
    public potionsData droppedData;
    public Transform shopContainer;

    public void OnDrop(PointerEventData eventData)
    { 
        GameObject droppedObj = eventData.pointerDrag;
        droppedData = droppedObj.GetComponent<potionsData>();
        droppedData.lastPos = this.transform;
        purchase.Invoke(droppedData.pData.cost);
    }

    public void noMoney()
    {
        droppedData.lastPos = shopContainer;
    }
}

[System.Serializable]
public class cashSend : UnityEvent<int>
{

}

