using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_AppearAnimation : MonoBehaviour
{
    float xScale, yScale;
    public bool isEnd = false;

    // Start is called before the first frame update
    void Start()
    {
        Reset();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isEnd == false)
        {
            transform.localScale = new Vector3(
                    transform.localScale.x + 5.0f * Time.deltaTime,
                    transform.localScale.y + 5.0f * Time.deltaTime,
                    1
                );
            if (transform.localScale.x >= xScale || transform.localScale.y >= yScale)
            {
                isEnd = true;
                transform.localScale = new Vector3(xScale, yScale, 1);
            }
        }
    }

    public void Reset()
    {
        xScale = 1;
        yScale = 1;
        transform.localScale = new Vector3(0, 0, 1);
        isEnd = false;
    }
}
