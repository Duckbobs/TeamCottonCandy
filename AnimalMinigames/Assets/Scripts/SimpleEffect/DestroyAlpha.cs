using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestroyAlpha : MonoBehaviour
{
    Image image;
    Text text;
    Shadow shadow;
    Outline outline;
    SometimeBounce sometimeBounce;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        text = GetComponentInChildren<Text>(true);
        shadow = GetComponentInChildren<Shadow>(true);
        outline = GetComponentInChildren<Outline>(true);
        sometimeBounce = GetComponent<SometimeBounce>();
    }

    // Update is called once per frame
    void Update()
    {
        if (sometimeBounce.isEnd)
        {
            image.color = new Color(image.color.r, image.color.g, image.color.b, image.color.a - Time.deltaTime);
            text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a - Time.deltaTime);
            shadow.effectColor = new Color(shadow.effectColor.r, shadow.effectColor.g, shadow.effectColor.b, shadow.effectColor.a - Time.deltaTime);
            outline.effectColor = new Color(outline.effectColor.r, outline.effectColor.g, outline.effectColor.b, outline.effectColor.a - Time.deltaTime);
            if (image.color.a <= 0.1f)
            {
                image.color = new Color(image.color.r, image.color.g, image.color.b, 1);
                text.color = new Color(text.color.r, text.color.g, text.color.b, 1);
                shadow.effectColor = new Color(shadow.effectColor.r, shadow.effectColor.g, shadow.effectColor.b, 1);
                outline.effectColor = new Color(outline.effectColor.r, outline.effectColor.g, outline.effectColor.b, 1);
                sometimeBounce.Reset();
                gameObject.SetActive(false);
            }
        }
    }
}
