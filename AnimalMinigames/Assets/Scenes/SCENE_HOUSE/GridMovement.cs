using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GridMovement : MonoBehaviour
{
    private static int selectID = -1;
    private Vector2 startMyPoint;
    private Vector2 startMousePoint;

    // Update is called once per frame
    void Update()
    {
        if (!HouseEditor.isEditorMode)
            return;

        if (gameObject.GetInstanceID() == selectID)
        {
            transform.localPosition = GetGridPosition(startMyPoint + GetMousePoint() - startMousePoint);
            Debug.Log("selectID : " + selectID);
        }
    }


    private Vector2 GetGridPosition(Vector2 pos)
    {
        Vector2 newVector = pos;
        /**************************************/
        // TODO // newVector의 X, Y 를 0.5 단위로 양자화 ( 더 가까운 지점으로 양자화 )

        float x_int = Mathf.Floor(newVector.x);
        float x = Mathf.Abs(newVector.x - x_int);
        newVector.x = (x >= 0 && x < 0.25) ? x_int : x_int + 0.5f;

        if (newVector.y > -0.25)
            newVector.y = 0;
        else if (newVector.y <= -0.25 && newVector.y > -0.75)
            newVector.y = -0.5f;
        else if (newVector.y <= -0.75 /*&& newVector.y > -1.25*/)
            newVector.y = -1.0f;

        /**************************************/



        /**************************************/
        // newVector의 X, Y 제한
        if (newVector.x <= 0)
            newVector.x = 0;
        if (newVector.x > 15 - GetComponent<BoxCollider2D>().size.x)
            newVector.x = 15 - GetComponent<BoxCollider2D>().size.x;
        if (newVector.y <= -1)
            newVector.y = -1;
        if (newVector.y >= 0)
            newVector.y = 0;
        /**************************************/
        return newVector;
    }


    private Vector2 GetMousePoint()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
    private void OnMouseUp()
    {
        if (!HouseEditor.isEditorMode)
            return;
        if (gameObject.GetInstanceID() == selectID)
            selectID = -1;
    }
    private void OnMouseDown()
    {
        Debug.Log("다운");
        if (!HouseEditor.isEditorMode)
            return;
        Debug.Log("다운2");
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (selectID == -1)
        {
            Debug.Log("다운 조건");

            selectID = gameObject.GetInstanceID();
            startMyPoint = transform.localPosition;
            startMousePoint = GetMousePoint();
        }
    }
}
