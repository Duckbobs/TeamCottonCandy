using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerObject : MonoBehaviour
{
    public string targetName;
    public string destroyTtargetName;
    public static GameObject tutoParent;

    private void Start()
    {
        if (gameObject.name == "TutoCanvas")
        {
            Debug.Log(gameObject.name);
            tutoParent = gameObject;
        }
    }
}
