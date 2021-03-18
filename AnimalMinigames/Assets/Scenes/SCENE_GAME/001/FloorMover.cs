﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorMover : MonoBehaviour
{
    public float floorSpeed = 0;
    public float floorWidth = 0;

    bool doScale = true;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (doScale)
        {
            Transform[] _o = GetComponentsInChildren<Transform>();
            foreach (Transform obj in _o)
                obj.transform.localScale = new Vector2(
                    obj.transform.localScale.x+0.001f, obj.transform.localScale.y);
            doScale = false;
        }

        float delta = Mathf.Min((float)System.Math.Round(Time.deltaTime, 7), 0.02f);
        float move = (float)System.Math.Round(floorSpeed * delta, 7);
        //Debug.Log(delta);
        float maxRight = 0;
        Transform rightObject = null;
        Transform destroyObject = null;
        Transform[] objects = GetComponentsInChildren<Transform>();
        foreach (Transform obj in objects)
        {
            if (obj.tag == "Floor")
            {
                if (obj.transform.localPosition.x <= 0)
                {
                    destroyObject = obj;
                }
                obj.transform.localPosition = new Vector2(obj.transform.localPosition.x - move, obj.transform.localPosition.y);
                if (obj.transform.localPosition.x > maxRight)
                {
                    maxRight = obj.transform.localPosition.x;
                    rightObject = obj;
                }
            }
        }
        if (destroyObject != null && rightObject != null)
        {
            destroyObject.transform.localPosition = new Vector2(rightObject.transform.localPosition.x + floorWidth, rightObject.transform.localPosition.y);
        }
    }
}
