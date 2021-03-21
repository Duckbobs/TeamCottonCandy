using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSelectorScroll : MonoBehaviour
{
    public Transform CameraTransform;
    private Vector3 MousePosition;

    private void OnMouseDown()
    {
        MousePosition = Input.mousePosition;
    }

    private void OnMouseDrag()
    {
        Vector3 distance = Input.mousePosition - MousePosition;
        MousePosition = Input.mousePosition;
        CameraTransform.Translate(new Vector3(0.0f, -distance.y, 0.0f) * Time.deltaTime);
    }
}
