using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITextAutoSet : MonoBehaviour
{
    Text uiText;
    public string key;
    // Start is called before the first frame update
    void Start()
    {
        uiText = this.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        uiText.text = Global.Get(key).ToString();
    }
}
