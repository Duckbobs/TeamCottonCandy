using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextMaker : MonoBehaviour
{
    public Text compTextUI;

    [System.Serializable]
    public struct Part
    {
        public bool isGlobal;
        public string text;
    }
    public List<Part> textList = new List<Part>();

    public void DoUpdate()
    {
        string str = "";
        foreach (Part item in textList)
        {
            if(item.isGlobal)
            {
                str += Global.Get(item.text);
            }
            else
            {
                str += item.text;
            }
        }
        compTextUI.text = str;
    }

    private void OnEnable()
    {
        DoUpdate();
    }
}
