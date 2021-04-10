using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasToWorld : MonoBehaviour
{
    public Transform WorldPos;
    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = Camera.main.WorldToScreenPoint(WorldPos.position);
    }
}
