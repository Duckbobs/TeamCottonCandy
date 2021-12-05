using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSlider : MonoBehaviour
{
    public string globalName;
    public Text compText;
    public Slider compSlider;

    public bool isPercent = true;

    public void Refresh()
    {
        compSlider.maxValue = Global.Get(globalName, "Max");
        compSlider.value = Global.Get(globalName);
        if (isPercent)
        {
            compText.text = (int)(compSlider.value / compSlider.maxValue * 100) + "%";
        }
        else
        {
            compText.text = Global.Get(globalName).ToString() + "/" + Global.Get(globalName, "Max").ToString();
        }
    }
    private void FixedUpdate()
    {
        Refresh();
    }
}
