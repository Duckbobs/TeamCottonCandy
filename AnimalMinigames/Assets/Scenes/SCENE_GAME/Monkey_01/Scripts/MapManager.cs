using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public GameObject[] mapList;
    public static bool isGameEnd = false;
    public GameObject gameEndObject;

    private int index = 0;
    Transform[] transforms;

    private void NextMap()
    {
        if(mapList.Length > index)
        {
            Debug.Log("NextMap!");
            if (mapList[index] != null)
                Instantiate(mapList[index], transform);
            index += 1;
            transforms = GetComponentsInChildren<Transform>();
            foreach (Transform trans in transforms)
            {
                if (trans != null && trans.gameObject != gameObject && trans.gameObject.tag == "Obstacle")
                {
                    if (trans.localPosition.y < -0.5f)
                    {
                        trans.gameObject.transform.localPosition = new Vector3(trans.localPosition.x, trans.localPosition.y, -9);
                    }
                }
            }
            GetComponent<FloorMover>().Refresh();
        }
        else
        {
            isGameEnd = true;
            gameEndObject.SetActive(true);
            Debug.Log("GameEnd!");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        isGameEnd = false;
        transforms = GetComponentsInChildren<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameEnd == false)
        {
            bool isEnd = true;
            foreach (Transform trans in transforms)
            {
                if (trans != null && trans.gameObject != gameObject && trans.gameObject.tag != "Untagged")
                {
                    isEnd = false;
                    //Debug.Log(trans.gameObject.name);
                    break;
                }
            }
            if (isEnd)
            {
                Transform[] transforms = GetComponentsInChildren<Transform>();
                foreach (var trans in transforms)
                {
                    if (trans.gameObject != null && trans.gameObject != gameObject)
                    {
                        Destroy(trans.gameObject);
                    }
                }
                NextMap();
            }
        }
    }
}
