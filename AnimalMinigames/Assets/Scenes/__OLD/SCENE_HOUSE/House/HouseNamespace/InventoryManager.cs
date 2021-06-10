using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace House
{
    public class InventoryManager
    {
        public static GameObject[] highlightedMenus = new GameObject[4];
        public static GameObject[] itemSlots = new GameObject[16];
        public static int currentPage = 0;

        public static void SwitchMenu(int index)
        {
            for( int i = 0; i != 4; i++ )
            {
                highlightedMenus[i].SetActive(i == index);
            }

            for( int i = 0; i != 16; i++ )
            {
                ItemManager.Item item = ItemManager.itemData.itemPages[index].items[i];
                if(item.sprite != null )
                {
                    itemSlots[i].SetActive(true);
                    itemSlots[i].GetComponent<Image>().sprite = item.sprite;
                }
                else
                {
                    itemSlots[i].SetActive(false);
                }
            }
            currentPage = index;
        }
        
        public static int GetItemCode(int index)
        {
            return currentPage * 16 + index;
        }
    }
}

