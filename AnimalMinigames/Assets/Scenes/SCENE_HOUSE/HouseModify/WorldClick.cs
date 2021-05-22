using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class WorldClick : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public GameObject blankItem;
    public Transform parent;
    public int itemCode;

    private GameObject focusedItem;
    private RectTransform rectTransform;
    private Image image;
    private Vector2 position;
    int gridY, gridX;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        GetComponent<Image>().color = new Color32(255, 255, 255, 0);
        
        focusedItem = GameObject.Instantiate(blankItem, parent);
        rectTransform = focusedItem.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = Input.mousePosition;
        rectTransform.localScale = new Vector3(commonVariable.worldScaleCoefficient, commonVariable.worldScaleCoefficient, 1);
        position = rectTransform.anchoredPosition;

        int y, x;
        float controlY, controlX;
        var scale = commonVariable.worldScaleCoefficient;
        var trans = commonVariable.worldTransform;
        var coo = Input.mousePosition;
        controlY = 600 + 100 * scale;
        controlX = 300 - 300 * scale + trans.x;
        y = Mathf.Min(1, (int)Mathf.Floor((controlY - coo.y) / 60 / scale));
        x = Mathf.Min(9, (int)Mathf.Floor((coo.x - controlX) / 60 / scale));
        commonVariable.currentItemCode = commonVariable.GetItemCode(y, x);
        gridY = y;
        gridX = x;

        //Debug.Log(Input.mousePosition);

        image = focusedItem.GetComponent<Image>();
        image.sprite = GetComponent<Image>().sprite;
    }

    public void OnDrag(PointerEventData eventData)
    {
        position += eventData.delta;

        if (onGrid())
        {
            //Debug.Log("OnGrid");
            image.color = new Color32(255, 255, 255, 80);
            int y, x;
            float controlY, controlX;
            var scale = commonVariable.worldScaleCoefficient;
            var trans = commonVariable.worldTransform;
            var coo = Input.mousePosition;
            controlY = 600 + 100 * scale;
            controlX = 300 - 300 * scale + trans.x;
            y = Mathf.Min(1, (int)Mathf.Floor((controlY - coo.y) / 60 / scale));
            x = Mathf.Min(9, (int)Mathf.Floor((coo.x - controlX) / 60 / scale));


            var pos = rectTransform.anchoredPosition;

            pos.x = 300 + scale * (-300 + x * 60 + 30) + trans.x;
            pos.y = 600 + scale * (100 - y * 60 - 30);

            rectTransform.anchoredPosition = pos;
        }
        else if (onTrashcan())
        {
            Debug.Log("OnCan");
            image.color = new Color32(255, 0, 0, 80);
            rectTransform.anchoredPosition = position;
        }
        else
        {
            image.color = new Color32(255, 255, 255, 80);
            rectTransform.anchoredPosition = position;
        }
    }

    bool onGrid()
    {
        float scale = commonVariable.worldScaleCoefficient;
        Vector2 trans = commonVariable.worldTransform;
        float minX, minY, maxX, maxY;
        // Control + Scale [ + Translation ]
        maxX = 300 + 300 * scale + trans.x;
        minX = 300 - 300 * scale + trans.x;
        maxY = 600 + 100 * scale;
        minY = 600 - 20 * scale;

        var coo = Input.mousePosition;
        return minX <= coo.x && coo.x <= maxX && minY <= coo.y && coo.y <= maxY;
    }

    bool onTrashcan()
    {
        float minX, minY, maxX, maxY;
        maxX = 600 - 0;
        minX = 600 - 100;
        maxY = 500 - 0;
        minY = 500 - 50;

        var coo = Input.mousePosition;
        return minX <= coo.x && coo.x <= maxX && minY <= coo.y && coo.y <= maxY;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Destroy(focusedItem);
        if (onGrid())
        {
            int y, x;
            float controlY, controlX;
            var scale = commonVariable.worldScaleCoefficient;
            var trans = commonVariable.worldTransform;
            var coo = Input.mousePosition;
            controlY = 600 + 100 * scale;
            controlX = 300 - 300 * scale + trans.x;
            y = Mathf.Min(1, (int)Mathf.Floor((controlY - coo.y) / 60 / scale));
            x = Mathf.Min(9, (int)Mathf.Floor((coo.x - controlX) / 60 / scale));
            if( commonVariable.AvailableToPut(y,x) )
            {
                commonVariable.PutWorldItem(gridY, gridX, -1);
                commonVariable.PutWorldItem(y, x, commonVariable.currentItemCode);
                Destroy(gameObject);
            }
            else
            {
                GetComponent<Image>().color = new Color32(255, 255, 255, 100);
            }
                
        }
        else if( onTrashcan() )
        {
            Destroy(gameObject);
        }
        
    }
}
