using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class StageSelectorEvent : MonoBehaviour
{
    public StageSelectorPanel StageSelectorPanel;
    public GameObject[] Stars;
    public GameObject[] Lock_active;
    public GameObject[] Flat_active;

    [System.Serializable]
    public struct Stage
    {
        public Sprite mainSprite;
        public string stageName;
    };
    public Stage stage;

    private void Awake()
    {
        StageSelectorPanel.Close();
        float nowStar = Global.Get(stage.stageName + "_nowStar");
        switch ((int)nowStar)
        {
            case 0:
                Debug.Log("Not Open");
                break;
            case 1:
                Stars[0].SetActive(true);
                break;
            case 2:
                Stars[0].SetActive(true);
                Stars[1].SetActive(true);
                break;
            case 3:
                Stars[0].SetActive(true);
                Stars[1].SetActive(true);
                Stars[2].SetActive(true);
                break;
        }

        float isUnlock = Global.Get(stage.stageName + "_isUnlock");
        switch ((int)isUnlock)
        {
            case 1:
                Lock_active[0].SetActive(false);
                Lock_active[1].SetActive(true);
                Flat_active[0].SetActive(false);
                Flat_active[1].SetActive(true);
                break;
        }
    }

    private void OnMouseUpAsButton()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        float isUnlock = Global.Get(stage.stageName + "_isUnlock");
        switch ((int)isUnlock)
        {
            case 0:
                Debug.Log("Not Open");
                break;
            case 1:
                Debug.Log("Unlock");
                Lock_active[0].SetActive(false);
                Lock_active[1].SetActive(false);
                Global.Set(stage.stageName + "_isUnlock", 2);
                break;
            case 2:
                Debug.Log("Open");
                StageSelectorPanel.Open(stage);
                break;
        }
    }
}
