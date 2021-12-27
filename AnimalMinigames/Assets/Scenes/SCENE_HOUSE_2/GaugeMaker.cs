using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GaugeMaker : MonoBehaviour
{
    public Slider compSliderUI;

    [System.Serializable]
    public struct Value
    {
        public bool isGlobal;
        public string value;
    }
    public List<Value> leftList = new List<Value>();
    public List<Value> rightList = new List<Value>();

    public void DoUpdate()
    {
        float left = 0;
        foreach (Value item in leftList)
        {
            if (item.isGlobal)
            {
                left += Global.Get(item.value);
            }
            else
            {
                left += float.Parse(item.value);
            }
        }
        float right = 0;
        foreach (Value item in rightList)
        {
            if (item.isGlobal)
            {
                right += Global.Get(item.value);
            }
            else
            {
                right += float.Parse(item.value);
            }
        }
        float percent = left / right;
        compSliderUI.value = percent;
    }

    private void OnEnable()
    {
        DoUpdate();
    }
}
