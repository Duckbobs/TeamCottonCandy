using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorMover : MonoBehaviour
{
    public float floorSpeed = 0;
    private float floorWidth = 0;
    List<Transform> objects;
    Transform rightObject = null;
    Transform destroyObject = null;
    float delta, move, maxRight;
    // Start is called before the first frame update
    void Start()
    {
        objects = new List<Transform>();
        Transform[] comps = GetComponentsInChildren<Transform>();

        foreach (Transform obj in comps)
        {
            if (obj.tag == "Floor")
            {
                obj.transform.localScale = new Vector2(obj.transform.localScale.x + 0.001f, obj.transform.localScale.y);
                objects.Add(obj);
            }
        }
        floorWidth = objects[0].gameObject.GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        delta = Mathf.Min((float)System.Math.Round(Time.deltaTime, 7), 0.02f);
        move = (float)System.Math.Round(floorSpeed * delta, 7);
        maxRight = 0;
        rightObject = null;
        destroyObject = null;
        foreach (Transform obj in objects)
        {
            if (obj.transform.localPosition.x <= 0)
                destroyObject = obj;
            obj.transform.localPosition = new Vector2(obj.transform.localPosition.x - move, obj.transform.localPosition.y);
            if (obj.transform.localPosition.x > maxRight)
            {
                maxRight = obj.transform.localPosition.x;
                rightObject = obj;
            }
        }
        if (destroyObject != null && rightObject != null)
            destroyObject.transform.localPosition = new Vector2(rightObject.transform.localPosition.x + floorWidth, rightObject.transform.localPosition.y);
    }
}
