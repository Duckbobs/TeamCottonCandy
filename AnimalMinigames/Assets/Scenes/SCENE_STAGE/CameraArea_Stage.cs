using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraArea_Stage : MonoBehaviour
{
    public bool canMove = true;
    public Transform Frame;
    public Transform Mover;
    Vector3 PrevMousePosition;

    bool isDrag = false;

    float frameWid, frameHei;
    float camHei, camWid;

    private void Start()
    {
        frameWid = Frame.gameObject.GetComponent<SpriteRenderer>().bounds.size.x;
        frameHei = Frame.gameObject.GetComponent<SpriteRenderer>().bounds.size.y;
    }
    private void Update()
    {
        camHei = Camera.main.orthographicSize * 2;
        camWid = camHei * Camera.main.aspect;

        float distance = Vector2.Distance((Vector2)Mover.position, (Vector2)transform.position);
        if (distance > 1f)
        {
            transform.position += (Vector3)(
                ((Vector2)Mover.position
                - (Vector2)transform.position).normalized * Time.deltaTime * 10 * distance);
        }

        if (isDrag) { isDrag = false; }
        else
        {
            Camera.main.transform.position = new Vector3(
              transform.position.x, transform.position.y, Camera.main.transform.position.z);
        }

        // 화면 프레임 움직임
        Vector3 newVec3 = -1 * (transform.position);
        newVec3.z = Frame.position.z;
        if (Camera.main.transform.position.x + camWid / 2 > newVec3.x + frameWid / 2)
            newVec3.x = Camera.main.transform.position.x + camWid / 2 -  frameWid / 2;
        if (Camera.main.transform.position.x - camWid / 2 < newVec3.x - frameWid / 2)
            newVec3.x = Camera.main.transform.position.x - camWid / 2 + frameWid / 2;
        if (Camera.main.transform.position.y + camHei / 2 > newVec3.y + frameHei / 2)
            newVec3.y = Camera.main.transform.position.y + camHei / 2 - frameHei / 2;
        if (Camera.main.transform.position.y - camHei / 2 < newVec3.y - frameHei / 2)
            newVec3.y = Camera.main.transform.position.y - camHei / 2 + frameHei / 2;
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
        Vector3 movePosition = new Vector3(distance.x * Time.deltaTime, distance.y * Time.deltaTime, 0.0f) * 3.0f;

        float maxSpd = 0.5f;
        if(Vector3.Distance(Vector3.zero, movePosition) > maxSpd)
        {
            movePosition = movePosition.normalized * maxSpd;
        }

        Mover.position += movePosition;
        transform.position += movePosition;
        Camera.main.transform.position = new Vector3(transform.position.x, transform.position.y, Camera.main.transform.position.z);
        isDrag = true;
    }
}
