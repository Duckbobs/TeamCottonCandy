using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyObject : MonoBehaviour
{
    public GameObject[] gameObjects;
    private void Start()
    {
        foreach (GameObject obj in gameObjects)
        {
            DontDestroyOnLoad(obj.gameObject);
        }
    }
}
