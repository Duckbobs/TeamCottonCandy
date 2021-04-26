using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneChangeButton : MonoBehaviour
{
    public bool isScreenArea;
    public string sceneName;

    public void SceneChange()
    {
        if (!isScreenArea)
        {
            SceneChanger.Load_Async(sceneName);
        }
    }
    private void OnMouseDown()
    {
        if (isScreenArea)
        {
            SceneChanger.Load_Async(sceneName);
        }
    }
}
