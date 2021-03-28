using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageSelectorPanel : MonoBehaviour
{
    private StageSelectorEvent.Stage OpenStage;
    public Image MainImage;

    public void Open(StageSelectorEvent.Stage stage)
    {
        OpenStage = stage;
        gameObject.SetActive(true);
        MainImage.sprite = stage.mainSprite;
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }

    public void StartStage()
    {
        SceneChanger.Load(OpenStage.stageName);
    }
}
