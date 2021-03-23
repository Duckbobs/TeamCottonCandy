using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class StageSelectorScroll : MonoBehaviour
{
    public Cinemachine.CinemachineVirtualCamera VirtualCamera;
    private Vector3 PrevMousePosition;
    private Collider2D Collider2D;

    private void Awake()
    {
        Collider2D = GetComponent<CompositeCollider2D>();
    }

    private void OnMouseDown()
    {
        PrevMousePosition = Input.mousePosition;
    }

    private void OnMouseDrag()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        Vector3 distance = PrevMousePosition - Input.mousePosition;
        PrevMousePosition = Input.mousePosition;
        Vector3 movePosition = VirtualCamera.transform.position + new Vector3(0.0f, distance.y * Time.deltaTime, 0.0f);
        if (!Collider2D.OverlapPoint(movePosition))
        {
            movePosition.y = Collider2D.bounds.ClosestPoint(movePosition).y;
        }
        VirtualCamera.transform.position = movePosition;
    }
}
