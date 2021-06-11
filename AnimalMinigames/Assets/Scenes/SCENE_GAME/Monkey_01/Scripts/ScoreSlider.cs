using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSlider : MonoBehaviour
{
    public string globalName;
    public Text compText;
    public Slider compSlider;

    public void Refresh()
    {
        compSlider.maxValue = Global.Get(globalName, "Max");
        compSlider.value = Global.Get(globalName);
        compText.text = compSlider.value.ToString() + "/" + compSlider.maxValue;
    }
    private void Update()
    {
        Refresh();
    }
}
