using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public static string stageName;

    public void StartStage()
    {
        stageName = ((int)Global.Get("Stage")).ToString();
        GetComponent<SceneChangeButton>().SceneChange();
    }
}
