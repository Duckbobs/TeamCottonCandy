using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace House
{
    public class WorldItemManager
    {

        public static GameObject worldFront;
        public static GameObject itemTemplate;
        public class Coo
        {
            public int x;
            public int y;
            public Coo( int _x, int _y )
            {
                x = _x;
                y = _y;
            }
        }
        public static int[,] slotData = new int[2, 10] { { -1, -1, -1, -1, -1, -1, -1, -1, -1, -1 }, { -1, -1, -1, -1, -1, -1, -1, -1, -1, -1 } };

        public static bool AvailableToPut(Coo grid)
        {
            //Debug.Log(String.Format("{0}, {1}", grid.x, grid.y));
            return slotData[grid.y, grid.x] == -1;
        }

        public static void PutWorldItem(int itemCode, Coo rootGrid)
        {
            Debug.Log(String.Format("{0}:{1},{2}", itemCode, rootGrid.x, rootGrid.y));
            //Debug.Log("wow");
            var item = ItemManager.GetItemByItemCode(itemCode);
            for( int i = 1; i != item.width; i++ )
            {
                for (int j = 0; j != item.height; j++)
                {
                    Debug.Log(String.Format("{0}, {1}", rootGrid.x + i, rootGrid.y + j));
                    slotData[rootGrid.y + j, rootGrid.x + i] = -3;
                }
            }
            for (int j = 1; j != item.height; j++)
            {
                slotData[rootGrid.y + j, rootGrid.x] = -2;
            }
            slotData[rootGrid.y, rootGrid.x] = itemCode;

            var focusedItem = GameObject.Instantiate(itemTemplate, worldFront.transform);
            focusedItem.GetComponent<WorldItem>().itemCode = itemCode;
            focusedItem.GetComponent<WorldItem>().rootGrid = rootGrid;

            var rect = focusedItem.GetComponent<RectTransform>();
            rect.anchoredPosition = new Vector2(rootGrid.x*60+30*item.width, rootGrid.y*-60-30*item.height);
           
            var scale = House.WorldTransformManager.scale;
            rect.localScale = new Vector3(item.width, item.height, 1);

            var image = focusedItem.GetComponent<Image>();
            image.sprite = item.sprite;
        }

        public static void RemoveWorldItem(Coo grid)
        {
            var rootGrid = GetRootGrid(grid);
            ItemManager.Item item = ItemManager.GetItemByItemCode(GetItemCode(rootGrid)); 
            for( int i = 0; i != item.width; i++ )
            {
                for (int j = 0; j != item.height; j++)
                {
                    slotData[rootGrid.y + j, rootGrid.x + i] = -1;
                }
            }
        }

        public static int GetItemCode(Coo grid)
        {
            Coo rootGrid = GetRootGrid(grid);
            return slotData[rootGrid.y, rootGrid.x];
        }

        public static Coo GetRootGrid(Coo grid)
        {
            if (slotData[grid.y, grid.x] == -3)
            {
                grid.x = grid.x - 1;
                return GetRootGrid(grid);
            }
            else if ( slotData[grid.y, grid.x] == -2)
            {
                grid.y = grid.y - 1;
                return GetRootGrid(grid);
            }
            return grid;
        }
    }
}

