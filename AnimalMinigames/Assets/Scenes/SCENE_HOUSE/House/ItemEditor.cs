using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ItemEditor : MonoBehaviour
{
    [SerializeField]
    public House.ItemManager.ItemData itemData = new House.ItemManager.ItemData();

    void Awake()
    {
        House.ItemManager.itemData = itemData;
    }
}