using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSystem_Monkey_01 : MonoBehaviour
{
    public Text text;
    // Update is called once per frame
    void Update()
    {
        text.text = StringUtil.NumberFormat(100000);
    }
}
