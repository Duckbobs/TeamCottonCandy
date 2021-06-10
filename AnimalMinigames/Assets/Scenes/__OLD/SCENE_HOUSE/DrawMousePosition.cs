using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrawMousePosition : MonoBehaviour
{
    public Text text_mouse;
    public Vector3 mousePos;

    private void Update()
    {
        Update_MousePosition();
    }

    private void Update_MousePosition()
    {
        mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos) - transform.position;


        string message = mousePos.ToString();
        text_mouse.text = message;
    }
}
