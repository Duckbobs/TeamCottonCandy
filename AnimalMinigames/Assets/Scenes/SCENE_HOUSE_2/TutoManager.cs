using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutoManager : MonoBehaviour
{
    public string globalName;
    public float equalTo;
    public float changeTo;
    public GameObject talkObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Global.Get(globalName) == equalTo)
        {
            Debug.Log(globalName + " to " + changeTo);
            Global.Set(globalName, changeTo);
            talkObject.SetActive(true);
        }
    }
}
