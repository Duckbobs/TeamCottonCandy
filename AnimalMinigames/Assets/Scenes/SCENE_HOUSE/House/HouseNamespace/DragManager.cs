using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace House
{
    public class DragManager : MonoBehaviour
    {
        public static GameObject frontScreen;
        
        public static GameObject dragTemplate;    

        public static GameObject focusedItem;
        public static RectTransform rect;
        public static Image image;
        public static RectTransform position;

        public static int itemCode;
        public static int itemWidth, itemHeight;
        
        public static void BeginDrag(int _itemCode)
        {
            string line1 = "";
            string line2 = "";
            for (int i = 0; i != 10; i++)
            {
                line1 = line1 + String.Format("{0},", WorldItemManager.slotData[0, i]);
                line2 = line2 + String.Format("{0},", WorldItemManager.slotData[1, i]);
            }
            Debug.Log( line1 + "\n" + line2);
            itemCode = _itemCode;
            House.PointerManager.UpdateMousePos();
            Debug.Log(itemCode);
            focusedItem = GameObject.Instantiate(dragTemplate, frontScreen.transform);
            

            var item = ItemManager.GetItemByItemCode(itemCode);

            rect = focusedItem.GetComponent<RectTransform>();
            rect.anchoredPosition = PointerManager.mousePos;
            position = rect;
            
            var scale = House.WorldTransformManager.scale;
            itemWidth = item.width;
            itemHeight = item.height;
            rect.localScale = new Vector3(scale*itemWidth, scale*itemHeight, 1);

            image = focusedItem.GetComponent<Image>();
            image.sprite = item.sprite;
        }

        public static void OnDrag()
        {
            PointerManager.UpdateMousePos();

            //Debug.Log(PointerManager.mousePos.x.ToString() + PointerManager.mousePos.y.ToString() + PointerManager.IsOnTrashcan().ToString());
            if (PointerManager.IsOnTrashcan())
            {
                image.color = new Color(255, 0, 0, 30);
            }
            else
            {
                image.color = new Color(255, 255, 255, 30);
            }

            if (PointerManager.IsOnGrid())
            {
                var snapPoint = GridToPoint(GetNearestGrid(itemWidth, itemHeight), itemWidth, itemHeight);
                rect.anchoredPosition = snapPoint;
            }
            else
            {
                rect.anchoredPosition = PointerManager.mousePos;
            }
            //rect = focusedItem.GetComponent<RectTransform>();
        }

        public static bool EndDrag()
        {
            
            if ( PointerManager.IsOnGrid() )
            {
                WorldItemManager.Coo grid = GetNearestGrid(itemWidth, itemHeight);
                var tmpGrid = new WorldItemManager.Coo(0,0);
                bool avail = true;
                //Debug.Log(String.Format("@@{0}, {1}",grid.x, grid.y));
                for( int i = 0; i != itemWidth; i++ )
                {
                    for( int j = 0; j != itemHeight; j++ )
                    {
                        tmpGrid.x = grid.x + i;
                        tmpGrid.y = grid.y + j;
                        //Debug.Log(String.Format("##{0}, {1}", i, j));
                        if (WorldItemManager.AvailableToPut(tmpGrid) == false)
                        {
                            avail = false;
                        }
                    }
                }
                Debug.Log(avail);
                if( avail )
                {
                    WorldItemManager.PutWorldItem(itemCode, grid);
                    Destroy(focusedItem);
                    return true;
                }
            }
            Destroy(focusedItem);
            return PointerManager.IsOnTrashcan();
        }

        public static WorldItemManager.Coo GetNearestGrid(int width, int height)
        {
            var mousePos = PointerManager.mousePos;
            var scale = WorldTransformManager.scale;
            var distant = 2000f;
            var ret = new Vector2(2000, 2000);
            int gridAnchorX = 0;
            int gridAnchorY = 0;

            var topLeft = new Vector2(WorldTransformManager.world.anchoredPosition.x + 300 - 300 * scale, -550 + 120 * scale);
            //Debug.Log(topLeft.x.ToString() + "," + topLeft.y.ToString());

            for (int i = 0; i <= 10 - width; i++)
            {
                var tmpX = topLeft.x + scale * (i * 60 + width * 30);
                if (Mathf.Abs(ret.x - mousePos.x) > Mathf.Abs(tmpX - mousePos.x))
                {
                    ret.x = tmpX;
                    gridAnchorX = i;
                }
            }
            for (int i = 0; i <= 2 - height; i++)
            {
                var tmpY = topLeft.y + scale * (i * -60 + height * -30);
                if (Mathf.Abs(ret.y - mousePos.y) > Mathf.Abs(tmpY - mousePos.y))
                {
                    ret.y = tmpY;
                    gridAnchorY = i;
                }
            }
            return new WorldItemManager.Coo(gridAnchorX, gridAnchorY) ;
        }

        public static Vector2 GridToPoint(WorldItemManager.Coo grid, int width, int height)
        {
            var scale = WorldTransformManager.scale;
            var topLeft = new Vector2(WorldTransformManager.world.anchoredPosition.x + 300 - 300 * scale, -550 + 120 * scale);
            return topLeft + scale * new Vector2(grid.x * 60 + width * 30, grid.y * -60 + height * -30);
        }
        
    }
}

