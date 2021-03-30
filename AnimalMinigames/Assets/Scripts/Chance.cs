using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Chance
{
    public static bool chance(float chance)
    {
        return (Random.Range(0.0f, 100.0f) <= chance);
    }
}
