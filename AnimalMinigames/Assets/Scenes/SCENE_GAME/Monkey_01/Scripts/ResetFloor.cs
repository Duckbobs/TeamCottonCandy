using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetFloor : MonoBehaviour
{
    static float moveXsign = 1;
    static float moveX = 0;
    float beforeX = -100;
    void Update()
    {
        if (beforeX < transform.localPosition.x)
        {
            DoReset();
        }
        beforeX = transform.localPosition.x;
    }

    void DoReset()
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
