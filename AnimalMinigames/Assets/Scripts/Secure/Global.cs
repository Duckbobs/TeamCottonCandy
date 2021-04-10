using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Global
{
    public static localValue ins = null;
    public static void SetAdd(string key, float value)
    {
        ins.SetAdd(key, value);
    }
    public static void Set(string key, float value)
    {
        ins.Set(key, value);
    }
    public static float Get(string key)
    {
        return ins.Get(key);
    }
}
