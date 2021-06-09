using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TalkManager : MonoBehaviour, IPointerClickHandler
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

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Clicked: " + eventData.pointerCurrentRaycast.gameObject.name);
        if (compAppearAnimation.isEnd)
        {
            nowText = "";
            compText.text = nowText;
            SoundManager.ui.PlayTouchSound();
        }
    }
    private void OnMouseUpAsButton()
    {
    }
}
