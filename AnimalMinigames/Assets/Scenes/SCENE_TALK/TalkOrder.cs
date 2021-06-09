using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkOrder : MonoBehaviour
{
    public bool canDestroy = true;
    TalkManager[] objects;
    // Start is called before the first frame update
    void Start()
    {
        objects = GetComponentsInChildren<TalkManager>();
        foreach (var item in objects)
        {
            item.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        bool exist = false;
        foreach (var item in objects)
        {
            if(item != null)
            {
                exist = true;
                item.gameObject.SetActive(true);
                break;
            }
        }

        if(exist == false)
        {
            FloorMover.isGameStop = false;
            //if (canDestroy)
            //{
                Destroy(gameObject);
            //}
            //else
            //{
            //    foreach (var item in objects)
            //    {
            //        item.gameObject.SetActive(false);
            //    }
            //}
        }
    }
}
