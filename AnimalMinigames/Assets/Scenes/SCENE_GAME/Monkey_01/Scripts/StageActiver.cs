using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageActiver : MonoBehaviour
{
    bool process = false;
    // Start is called before the first frame update
    void Start()
    {
    }
    private void Update()
    {
        if (process == false)
        {
            process = true;
            MapManager[] stages = GetComponentsInChildren<MapManager>(true);
            foreach (MapManager item in stages)
            {
                item.gameObject.SetActive(true);
            }
            foreach (MapManager item in stages)
            {
                if (StageManager.stageName == item.gameObject.name)
                {
                    item.gameObject.SetActive(true);
                    return;
                }
            }
        }
    }
}
