using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_BtnDownEvent_Monkey : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public bool isBtnDown = false;
    float pressedTime = 0;

    private void Update()
    {
        if (isBtnDown)
        {
            if (Time.time - pressedTime > 0.1f)
            {
                FloorMover.playerSpeed += 0.1f;
            }
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (!isBtnDown)
        {
            pressedTime = Time.time;
            isBtnDown = true;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isBtnDown = false;
    }

}