using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyObject : MonoBehaviour
{
    public GameObject[] gameObjects;
    void OnEnable()
    {
        foreach (GameObject obj in gameObjects)
        {
            DontDestroyOnLoad(obj.gameObject);
        }
    }
}
