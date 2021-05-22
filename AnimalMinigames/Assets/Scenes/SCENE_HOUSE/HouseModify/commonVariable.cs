using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class commonVariable : MonoBehaviour
{
    public int countOfSprites = 64;
    public Sprite[] _spriteData;
    public int countOfInventoryMenu = 4;
    public GameObject[] _inventoryMenu;
    public GameObject _worldItem;

    static public Vector2 worldTransform;
    static public float worldScaleCoefficient = 1.0f;

    static public int onGrid = 0;
    static public int gridX;
    static public int gridY;

    static public bool onTrashcan;
    
    static public GameObject tempItem;
    static public Sprite[] spriteData;
    static public int[] slotData;
    static public int currentItemCode;
    static public int currentTheme;
    static public GameObject[] inventoryMenu;
    static public GameObject worldItem;

    void Awake()
    {
        spriteData = new Sprite[countOfSprites];
        for( int i = 0; i != countOfSprites; i++)
        {
            spriteData[i] = _spriteData[i];
        }
        inventoryMenu = new GameObject[countOfInventoryMenu];
        for( int i = 0; i != countOfInventoryMenu; i++)
        {
            inventoryMenu[i] = _inventoryMenu[i];
        }
        worldItem = _worldItem;
        slotData = new int[20];
        for( int i = 0; i != 20; i++ )
        {
            slotData[i] = -1;
        }
    }

    
    static public void PutWorldItem(int y, int x, int ItemCode)
    {
        slotData[y * 10 + x] = ItemCode;
        if (ItemCode == -1) return;
        GameObject world = GameObject.Find("World");
        var focusedItem = GameObject.Instantiate(worldItem, world.transform);
        var image = focusedItem.GetComponent<Image>();
        image.sprite = spriteData[ItemCode];
        var rectTransform = focusedItem.GetComponent<RectTransform>();
        var pos = rectTransform.anchoredPosition;
        pos.y = -60 * y - 30;
        pos.x = 60 * x + 30;
        rectTransform.anchoredPosition = pos;
    }

    static public bool AvailableToPut(int y, int x)
    {
        return slotData[y * 10 + x] == -1;
    }

    static public int GetItemCode(int y, int x)
    {
        return slotData[y * 10 + x];
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
