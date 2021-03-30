using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StringUtil
{
    public static string NumberFormat(int value)
    {
        return String.Format("{0:#,###}", value);
    }
}
