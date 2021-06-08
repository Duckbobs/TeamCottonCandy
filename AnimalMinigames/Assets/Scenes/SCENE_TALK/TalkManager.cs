using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TalkManager : MonoBehaviour
{
    public Text compText;
    public UI_AppearAnimation compAppearAnimation;
    public SometimeBounce compSometimeBounce;
    public string[] textArray;
    int index = 0;
    string nowText = "";

    // Update is called once per frame
    void Update()
    {
        if (nowText == "")
        {
            if (index < textArray.Length)
            {
                nowText = textArray[index];
                index += 1;

                compAppearAnimation.Reset();
                compSometimeBounce.Reset();
                compText.text = nowText;
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnMouseUpAsButton()
    {
        if (compAppearAnimation.isEnd)
        {
            nowText = "";
            compText.text = nowText;
            SoundManager.ui.PlayTouchSound();
        }
    }
}
