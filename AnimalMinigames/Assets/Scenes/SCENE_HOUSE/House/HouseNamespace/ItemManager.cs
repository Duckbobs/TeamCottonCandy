using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace House
{
    public class ItemManager
    {
        [Serializable]
        public class Item
        {
            public Sprite sprite;
            public int itemCode;
            public int width;
            public int height;

            public Item(int _itemCode)
            {
                itemCode = _itemCode;
            }
        }

        [Serializable]
        public class ItemPage
        {
            public Item[] items = new Item[16];

            public ItemPage(int pageNumber)
            {
                for (int i = 0; i != 16; i++)
                {
                    items[i] = new Item(16 * pageNumber + i);
                }
            }
        }

        [Serializable]
        public class ItemData
        {
            public ItemPage[] itemPages = new ItemPage[4];

            public ItemData()
            {
                for (int i = 0; i != 4; i++)
                {
                    itemPages[i] = new ItemPage(i);
                }
            }
        }

        public static ItemData itemData;

        public static Item GetItemByItemCode( int itemCode )
        {
            return itemData.itemPages[itemCode / 16].items[itemCode % 16];
        }
    }
}

