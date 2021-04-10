using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraArea_Stage : MonoBehaviour
{
    public Transform Frame;
    public Transform Mover;
    Vector3 PrevMousePosition;

    bool isDrag = false;
    private void Update()
    {
        float distance = Vector2.Distance((Vector2)Mover.position, (Vector2)transform.position);
        if (distance > 1f)
        {
            transform.position += (Vector3)(((Vector2)Mover.position - (Vector2)transform.position).normalized * Time.deltaTime * 10 * distance);
        }
        if (isDrag)
        {
            isDrag = false;
        }
        else
        {
            Camera.main.transform.position = new Vector3(transform.position.x, transform.position.y, Camera.main.transform.position.z);
        }

        Vector3 newVec3 = (transform.position) * -1;
        newVec3.z = Frame.position.z;
        Frame.position = newVec3;
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
        Vector3 movePosition = new Vector3(distance.x * Time.deltaTime, distance.y * Time.deltaTime, 0.0f);

        Mover.position += movePosition;
        transform.position += movePosition;
        Camera.main.transform.position = new Vector3(transform.position.x, transform.position.y, Camera.main.transform.position.z);
        isDrag = true;
    }
}
