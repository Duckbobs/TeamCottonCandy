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
        if (topObject.transform.localPosition.y != distance)
            topObject.transform.localPosition = new Vector3(0, Mathf.Lerp(topObject.transform.localPosition.y, distance, 0.05f), topObject.transform.localPosition.z);
        if (bottomObject.transform.localPosition.y != -distance)
            bottomObject.transform.localPosition = new Vector3(0, Mathf.Lerp(bottomObject.transform.localPosition.y, -distance, 0.05f), bottomObject.transform.localPosition.z);
    }
}
