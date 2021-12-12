using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActiveWithGlobalValue : MonoBehaviour
{
    public enum Type {
        EqualTo,
        GreaterThan,
        LessThan,
        GreaterThanOrEqualTo,
        LessThanOrEqualTo
    }
    public string valueName;
    public float value;
    public Type type;
    public bool setActive;
    public GameObject targetObject;
    // Update is called once per frame
    void FixedUpdate()
    {
        bool result = false;
        switch (type)
        {
            case Type.EqualTo:
                result = (Global.Get(valueName) == value);
                break;
            case Type.GreaterThan:
                result = (Global.Get(valueName) > value);
                break;
            case Type.LessThan:
                result = (Global.Get(valueName) < value);
                break;
            case Type.GreaterThanOrEqualTo:
                result = (Global.Get(valueName) >= value);
                break;
            case Type.LessThanOrEqualTo:
                result = (Global.Get(valueName) <= value);
                break;
        }
        targetObject.SetActive(result ? setActive : !setActive);
    }
}
