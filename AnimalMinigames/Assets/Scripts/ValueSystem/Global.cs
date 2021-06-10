using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Global
{
    public static float TRUE = 1.0f;
    public static float FALSE = 0.0f;

    public static localValue ins = null;
    public static void Add(string key, float value)
    {
        ins.Add(key, value);
    }
    public static void Add(string key, string key2, float value)
    {
        ins.Add(key + key2, value);
    }
    public static void Set(string key, float value)
    {
        ins.Set(key, value);
    }
    public static void Set(string key, string key2, float value)
    {
        ins.Set(key + key2, value);
    }
    public static float Get(string key)
    {
        return ins.Get(key);
    }
    public static float Get(string key, string key2)
    {
        return ins.Get(key + key2);
    }
}
