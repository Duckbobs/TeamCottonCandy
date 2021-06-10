using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TalkManager : MonoBehaviour, IPointerClickHandler
{
    public Text compText;
    public UI_AppearAnimation compAppearAnimation = null;
    public SometimeBounce compSometimeBounce;
    public GameObject focusObject = null;
    public GameObject startDestroyObject = null;
    public GameObject endFocusObject = null;
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
                if (startDestroyObject != null)
                {
                    Destroy(startDestroyObject);
                    startDestroyObject = null;
                }
                nowText = textArray[index];
                index += 1;

                if(compAppearAnimation != null)
                    compAppearAnimation.Reset();
                compSometimeBounce.Reset();
                compText.text = nowText;

                if (SoundManager.ui != null)
                    SoundManager.ui.PlayPopSound();
            }
            else
            {
                if (focusObject != null)
                    focusObject.SetActive(true);
                Destroy(gameObject);
            }
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Clicked: " + eventData.pointerCurrentRaycast.gameObject.name);
        if (compAppearAnimation == null || compAppearAnimation.isEnd)
        {
            nowText = "";
            compText.text = nowText;

            if (index < textArray.Length) {
                if (SoundManager.ui != null)
                    SoundManager.ui.PlayPopSound();
            }
        }
    }
    private void OnMouseUpAsButton()
    {
    }
}
