using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WorldTransform : MonoBehaviour, IDragHandler
{
    public float zoomSpeed = 1.0f;
    public float maxZoom = 2.0f;
    public float minZoom = 1.0f;
    private RectTransform rectTransform;
    private Vector3 prevMousePosition;
    private bool mouseButtonPressed = false;
    public float extent = 0;
   
    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        zoom();
        autoTranslate();
        commonVariable.worldTransform = rectTransform.anchoredPosition;
        //Debug.Log(commonVariable.worldTransform);
    }

    public void OnDrag(PointerEventData eventData)
    {
        //Debug.Log("Wow");
        var position = rectTransform.anchoredPosition;
        position.x += eventData.delta.x;
        //position += eventData.delta;
        rectTransform.anchoredPosition = position;
    }

    void zoom()
    {
        float zoomDifference = Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        var scale = rectTransform.localScale;
        if (zoomDifference < 0)
        {
            commonVariable.worldScaleCoefficient = Mathf.Max(minZoom, commonVariable.worldScaleCoefficient + zoomDifference);
        }
        else
        {
            commonVariable.worldScaleCoefficient = Mathf.Min(maxZoom, commonVariable.worldScaleCoefficient + zoomDifference);
        }
        scale.x = scale.y = commonVariable.worldScaleCoefficient;
        rectTransform.localScale = scale;
        extent = 300 * (commonVariable.worldScaleCoefficient - 1);
    }

    void autoTranslate()
    {
        var position = rectTransform.anchoredPosition;
        position.x = Mathf.Max(-extent, Mathf.Min(extent, position.x));
        rectTransform.anchoredPosition = position;
    }

}
