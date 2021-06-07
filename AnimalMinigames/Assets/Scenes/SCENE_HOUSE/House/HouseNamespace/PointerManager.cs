using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace House
{
    public class PointerManager
    {
        public static Vector2 mousePos;
        public static Transform gridArea;

        public static void UpdateMousePos()
        {
            Vector2 rawMousePos = Input.mousePosition;
            mousePos.x = rawMousePos.x * 600 / Screen.width;
            mousePos.y = (rawMousePos.y - Screen.height) * 600 / Screen.width;

            //Debug.Log(mousePos.y);
        }

        public static bool IsOnGrid()
        {
            return -550 <= mousePos.y && mousePos.y <= -550 + 120 * WorldTransformManager.scale;
        }

        public static bool IsOnTrashcan()
        {
            return -700 <= mousePos.y && mousePos.y <= -650 && 500 <= mousePos.x && mousePos.x <= 600;
        }

    }
}

