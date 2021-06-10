using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace House
{
    public class WorldTransformManager
    {
        public static float scale = 1f;
        public static float minScale = 1f;
        public static float maxScale = 2f;
        public static float zoomSpeed = 1f;
        public static float extent = 0;

        public static RectTransform world;

        public static void ScaleWorld(float difference)
        {
            //Debug.Log(difference);
            var worldScale = world.localScale;
            scale = Mathf.Max(minScale, Mathf.Min(maxScale, scale + difference * zoomSpeed));
            worldScale.x = worldScale.y = scale;
            world.localScale = worldScale;
            extent = 300 * (scale - 1);
            Translate(0f);
            //Debug.Log(scale);
        }

        public static void Translate(float difference)
        {
            var position = world.anchoredPosition;
            position.x = Mathf.Max(-extent, Mathf.Min(extent, position.x + difference));
            world.anchoredPosition = position;
        }

       
    }
}

