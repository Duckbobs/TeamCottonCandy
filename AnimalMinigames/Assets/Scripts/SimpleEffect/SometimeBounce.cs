using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SometimeBounce : MonoBehaviour
{
    public float someTime = 0;
    float _someTime = 0;
    float xScale, yScale;
    public bool isEnd = false;
    UI_AppearAnimation appearAnimation = null;

    public float strong = 0.2f;
    float value;
    float t = 0;
    // Start is called before the first frame update
    void Start()
    {
        value = strong;
        Reset();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (someTime > 0)
        {
            _someTime += Time.deltaTime;
            if (_someTime >= someTime)
            {
                _someTime = 0;
                isEnd = false;
                value = strong;
                t = 0;
            }
        }
        if (appearAnimation != null)
        {
            if (!appearAnimation.isEnd)
            {
                //Debug.Log(appearAnimation);
                t = Time.time;
                return;
            }
        }
        if (isEnd == false)
        {
            value -= 0.5f * Time.deltaTime;

            transform.localScale = new Vector3(
                    xScale + Mathf.Sin((Time.time - t) * 20) * value,
                    yScale + Mathf.Sin((Time.time - t) * 20) * value,
                    1
                );

            if (value < 0)
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
        isEnd = false;
        value = strong;
        t = 0;
        appearAnimation = gameObject.GetComponent<UI_AppearAnimation>();
    }
}
