using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventoryItem : MonoBehaviour, IPointerDownHandler, IDragHandler, IEndDragHandler
{
    public int index;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        var itemCode = House.InventoryManager.GetItemCode(index);
        House.DragManager.BeginDrag(itemCode);
    }
    public void OnDrag(PointerEventData eventData)
    {
        House.DragManager.OnDrag();
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        House.DragManager.EndDrag();
    }
}
