using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageManager : MonoBehaviour
{
    public static string stageName;
    public GameObject alertHeart;
    public Text stageText;

    private void Start()
    {
        stageText.text = "레벨 " + ((int)Global.Get("Stage")).ToString();
    }
    public void StartStage()
    {
        if (Global.Get("Key") > 0)
        {
            Global.Add("Key", -1);
            stageName = ((int)Global.Get("Stage")).ToString();
            GetComponent<SceneChangeButton>().SceneChange();
        }
        else
        {
            alertHeart.SetActive(true);
        }
    }
}
