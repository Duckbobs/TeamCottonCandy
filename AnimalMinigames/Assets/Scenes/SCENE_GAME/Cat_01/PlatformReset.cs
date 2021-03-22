using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformReset : MonoBehaviour
{
    static float moveXsign = 1;
    static float moveX = 0;
    float beforeX = -100;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (beforeX < transform.localPosition.x)
        {
            doReset();
        }
        beforeX = transform.localPosition.x;
    }

    void doReset()
    {
        if (moveXsign < 0)
        {
            if (moveX < -1)
            {
                moveXsign = 1;
            }
        }
        else
        {
            if (moveX > 1)
            {
                moveXsign = -1;
            }
        }
        moveX += moveXsign * 1f;
        transform.localPosition = new Vector3(
            transform.localPosition.x, transform.localPosition.y + moveX, transform.localPosition.z);
    }
}
