using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackEnd : MonoBehaviour
{
    void Awake()
    {
        GameObject highlitedMenus = GameObject.Find("HighlightedMenu");
        for (int i = 0; i != 4; i++)
        {
            //Debug.Log(highlitedMenus.transform.GetChild(i).name);
            House.InventoryManager.highlightedMenus[i] = highlitedMenus.transform.GetChild(i).gameObject;
        }

        GameObject itemSlots = GameObject.Find("ItemArea").transform.GetChild(1).gameObject;
        for (int i = 0; i != 16; i++)
        {
            House.InventoryManager.itemSlots[i] = itemSlots.transform.GetChild(i).gameObject;
        }

        House.WorldTransformManager.world = GameObject.Find("World").GetComponent<RectTransform>();

        House.DragManager.frontScreen = GameObject.Find("FrontScreen");
        House.DragManager.dragTemplate = GameObject.Find("DragTemplate");

        House.WorldItemManager.worldFront = GameObject.Find("WorldFront");
        House.WorldItemManager.itemTemplate = GameObject.Find("ItemTemplate");

        House.ButtonManager.inModifyingScreen = GameObject.FindGameObjectsWithTag("HouseModify");
        House.ButtonManager.inAppliedScreen = GameObject.FindGameObjectsWithTag("HouseApplied");
    }

    void Start()
    {
        House.ButtonManager.SetMode("modifying");
        House.InventoryManager.SwitchMenu(0);
        //House.WorldTransformManager.GetNearestSnapPoint(2, 2);
    }

    void Update()
    {
        //House.PointerManager.UpdateMousePos(Input.mousePosition);
        //Debug.Log(House.PointerManager.IsOnTrashcan());
        //Debug.Log("wow");
    }
}
