using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WorldTransform : MonoBehaviour, IDragHandler
{
    void Update()
    {
        House.WorldTransformManager.ScaleWorld(Input.GetAxis("Mouse ScrollWheel"));
    }

    public void OnDrag(PointerEventData eventData)
    {
        House.WorldTransformManager.Translate(eventData.delta.x);
    }
}
