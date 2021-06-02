using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class WorldItem : MonoBehaviour, IPointerDownHandler, IDragHandler, IEndDragHandler
{
    public int itemCode;
    public House.WorldItemManager.Coo rootGrid;
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
        //rootGrid = new WorldItemManager.Coo (House.House.WorldItemManager.GetRootGrid(House.DragManager.GetNearestGrid(1, 1)));
        //itemCode = House.WorldItemManager.GetItemCode(rootGrid);
        House.DragManager.BeginDrag(itemCode);


        House.WorldItemManager.RemoveWorldItem(House.DragManager.GetNearestGrid(1, 1));
        gameObject.GetComponent<CanvasGroup>().alpha = 0;
    }
    public void OnDrag(PointerEventData eventData)
    {
        House.DragManager.OnDrag();
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        if( House.DragManager.EndDrag() == false)
        {
            Debug.Log(string.Format("F,{0},{1},{2}",itemCode, rootGrid.x, rootGrid.y));
            House.WorldItemManager.PutWorldItem(itemCode, rootGrid);
        }
        Destroy(gameObject);
    }
}
