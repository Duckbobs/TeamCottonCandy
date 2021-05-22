using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class InventoryMenuClick : MonoBehaviour, IPointerClickHandler
{

    public GameObject signboard;
    public int index;
    
    public void OnPointerClick(PointerEventData eventData)
    {
        foreach( var menu in commonVariable.inventoryMenu)
        {
            menu.SetActive(false);
        }
        signboard.SetActive(true);


        commonVariable.currentTheme = index;

        for (int i = 0; i != 16; i++)
        {
            string name = "Item_" + (i + 1).ToString();
            GameObject currentInventoryItem = GameObject.Find(name);
            currentInventoryItem.GetComponent<Image>().sprite = commonVariable.spriteData[index*16 + i];
        }
    }
}
