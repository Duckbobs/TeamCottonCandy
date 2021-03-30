using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_BtnDownEvent : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public bool isBtnDown = false;

    private void Update()
    {
        if (isBtnDown)
        {
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isBtnDown = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isBtnDown = false;
    }

}