using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorMover : MonoBehaviour
{
    public float floorSpeed = 0;
    public bool isLoop = true;

    private float floorWidth = 0;
    private float floorStartWidth = 0;
    List<Transform> objects;
    Transform rightObject = null;
    Transform destroyObject = null;
    float delta, move, maxRight;
    // Start is called before the first frame update
    void Start()
    {
        Refresh();
    }

    public void Refresh()
    {
        objects = new List<Transform>();
        Transform[] comps = GetComponentsInChildren<Transform>();

        foreach (Transform obj in comps)
        {
            if (obj.tag == "Floor" || obj.tag == "Item" || obj.tag == "Coin" || obj.tag == "Obstacle")
            {
                obj.transform.localScale = new Vector3(obj.transform.localScale.x, obj.transform.localScale.y, obj.transform.localScale.z);
                objects.Add(obj);

                if (obj.transform.localPosition.x + obj.GetComponent<SpriteRenderer>().sprite.rect.width / 100 > floorWidth)
                {
                    floorWidth = obj.transform.localPosition.x + obj.GetComponent<SpriteRenderer>().sprite.rect.width / 100;
                }
                if (obj.transform.localPosition.x < floorStartWidth)
                {
                    floorStartWidth = obj.transform.localPosition.x;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        delta = Mathf.Min((float)System.Math.Round(Time.deltaTime, 7), 0.02f);
        move = (float)System.Math.Round((floorSpeed + PlayerMovement.playerSpeed) * delta, 7);
        foreach (Transform obj in objects)
        {
            if (obj != null)
            {
                obj.transform.localPosition = new Vector3(obj.transform.localPosition.x - move, obj.transform.localPosition.y, obj.transform.localPosition.z);
                if (obj.transform.localPosition.x <= 0)
                {
                    if (isLoop)
                    {
                        obj.transform.localPosition = new Vector3(obj.transform.localPosition.x + floorWidth + floorStartWidth, obj.transform.localPosition.y, obj.transform.localPosition.z);
                    }
                    else
                    {
                        Destroy(obj.gameObject);
                    }
                }
            }
        }
    }
}
