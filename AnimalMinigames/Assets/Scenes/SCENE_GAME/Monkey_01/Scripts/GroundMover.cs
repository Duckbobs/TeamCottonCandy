using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMover : MonoBehaviour
{
    public GameObject topObject;
    public GameObject bottomObject;
    public float ct_distance = 1;
    public static float distance = 1;

    // Update is called once per frame
    void Update()
    {
        distance = ct_distance;

        if(distance == 0)
        {
            float yPlus = Mathf.Lerp(topObject.transform.localPosition.y, -5, 0.1f);
            topObject.transform.localPosition = new Vector3(
                    0, yPlus, topObject.transform.localPosition.z
                );
            bottomObject.transform.localPosition = new Vector3(
                    0, yPlus, bottomObject.transform.localPosition.z
                );
            transform.localPosition = new Vector3(
                    0, yPlus, transform.localPosition.z
                );
        } else
        {
            if (topObject.transform.localPosition.y != distance)
                topObject.transform.localPosition = new Vector3(
                        0, Mathf.Lerp(topObject.transform.localPosition.y, distance, 0.1f), topObject.transform.localPosition.z
                    );

            if (bottomObject.transform.localPosition.y != -distance)
                bottomObject.transform.localPosition = new Vector3(
                        0, Mathf.Lerp(bottomObject.transform.localPosition.y, -distance, 0.1f), bottomObject.transform.localPosition.z
                    );

            float yPlus = Mathf.Lerp(transform.localPosition.y, 0.0f, 0.1f);
            transform.localPosition = new Vector3(
                    0, yPlus, transform.localPosition.z
                );
        }
    }
}
