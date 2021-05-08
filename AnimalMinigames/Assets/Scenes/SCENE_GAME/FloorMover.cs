using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorMover : MonoBehaviour
{
    public static float playerSpeed = 0;
    public float floorSpeed = 0;
    public bool isLoop = true;

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

                if (obj.transform.localPosition.x > floorWidth)
                {
                    floorWidth = obj.transform.localPosition.x;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        delta = Mathf.Min((float)System.Math.Round(Time.deltaTime, 7), 0.02f);
        move = (float)System.Math.Round((floorSpeed + playerSpeed) * delta, 7);
        foreach (Transform obj in objects)
        {
            obj.transform.localPosition = new Vector2(obj.transform.localPosition.x - move, obj.transform.localPosition.y);
            if (obj.transform.localPosition.x <= 0)
            {
                if (isLoop)
                {
                    obj.transform.localPosition = new Vector2(obj.localPosition.x + floorWidth, obj.transform.localPosition.y);
                }
            }
        }
    }
}
