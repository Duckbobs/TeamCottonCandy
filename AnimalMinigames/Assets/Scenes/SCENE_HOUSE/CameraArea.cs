using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraArea : MonoBehaviour
{
    public Cinemachine.CinemachineVirtualCamera VirtualCamera;
    public float MinCameraScale = 5.0f;
    public float MaxCameraScale = 15.0f;
    public float ZoomSpeed = 10.0f;

    public string ExtendTag = "Floor";
    public float ExtendHeight = -5.0f;

    private BoxCollider2D CameraArea2D;

    private void Start()
    {
        CameraArea2D = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        // 마우스 스크롤 입력을 하였을 경우에 대한 처리입니다.
        float distance = Input.GetAxis("Mouse ScrollWheel") * -1 * ZoomSpeed;
        if (distance != 0.0f)
            VirtualCamera.m_Lens.OrthographicSize += distance;
        
        // 카메라 확대 축소가 범위를 벗어나지 않도록 합니다.
        if (VirtualCamera.m_Lens.OrthographicSize > MaxCameraScale) VirtualCamera.m_Lens.OrthographicSize = MaxCameraScale;
        if (VirtualCamera.m_Lens.OrthographicSize < MinCameraScale) VirtualCamera.m_Lens.OrthographicSize = MinCameraScale;

        // 카메라의 영역을 땅에 맞게 설정합니다.
        GameObject[] floorObjects = GameObject.FindGameObjectsWithTag(ExtendTag);
        foreach (GameObject floorObject in floorObjects)
        {
            float camDownArea = transform.position.y - CameraArea2D.size.y * 0.5f;
            float objDownArea = floorObject.transform.position.y + ExtendHeight;

            if (camDownArea > objDownArea)
                CameraArea2D.size = new Vector2(CameraArea2D.size.x, -objDownArea * 2.0f);
        }
    }
}
