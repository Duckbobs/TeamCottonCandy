using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinMoving : MonoBehaviour
{
    public float xValue, yValue;
    float X, Y, t;

    // Start is called before the first frame update
    void Start()
    {
        X = transform.position.x;
        Y = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;
        transform.position = new Vector3(
            X + Mathf.Sin(t * 10) * xValue, Y + Mathf.Sin(t * 10) * yValue, transform.position.z
        );

    }
}
