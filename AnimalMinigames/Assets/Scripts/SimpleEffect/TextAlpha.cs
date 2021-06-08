using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextAlpha : MonoBehaviour
{
    public float speed = 1.0f;
    public Text compText;
    float alpha = 1.0f;
    float sign = -1.0f;
    // Update is called once per frame
    void Update()
    {
        if(alpha <= 0.7f)
            sign = 1.0f;
        else if (alpha >= 1.0f)
            sign = -1.0f;

        alpha += sign * speed * Time.deltaTime;

        compText.color = new Color(
            compText.color.r
            , compText.color.g
            , compText.color.b
            , alpha);
    }
}
