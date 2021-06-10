using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneChangeButton : MonoBehaviour
{
    public bool isScreenArea;
    public string sceneName;
    bool progress = false;

    public void SceneChange_Sync()
    {
        if (!isScreenArea && !progress)
        {
            SceneChanger.Load(sceneName);
            progress = true;
        }
    }
    public void SceneChange()
    {
        if (!isScreenArea && !progress)
        {
            SceneChanger.Load_Async(sceneName);
            progress = true;
        }
    }
    private void OnMouseDown()
    {
        if (isScreenArea && !progress)
        {
            SceneChanger.Load_Async(sceneName);
            progress = true;
        }
    }
}
