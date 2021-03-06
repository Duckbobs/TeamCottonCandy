using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_PanelControl : MonoBehaviour
{
    public void ControlUI(string uiName)
    {
        GameObject uiObject = null;
        bool isActive = false;
        ////////////////////////////////////////////////////////////
        // 해당 이름의 UI_Panel UI를 찾아 uiObject, isActive 설정
        GameObject ObCanvas = GameObject.Find("Canvas");
        for (int i = 1; i < ObCanvas.transform.childCount; i++)
        {
            if (ObCanvas.transform.GetChild(i).GetComponent<UI_Panel>().uiName.Equals(uiName))
            {
                uiObject = ObCanvas.transform.GetChild(i).gameObject;
                isActive = uiObject.active;
                Debug.Log(uiObject.name);
                break;
            }
        }
        ////////////////////////////////////////////////////////////
        if (isActive)
        {
            CloseUI(uiObject);
        }
        else
        {
            OpenUI(uiObject);
        }
    }

    private void OpenUI(GameObject uiObject)
    {
        // Active True.
        uiObject.SetActive(true);
    }
    private void CloseUI(GameObject uiObject)
    {
        // Active False.
        uiObject.SetActive(false);
    }
}
