using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class StageSelectorEvent : MonoBehaviour
{
    public StageSelectorPanel StageSelectorPanel;

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
    }

    private void OnMouseUpAsButton()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        float isUnlock = Global.Get(stage.stageName);
        switch (isUnlock)
        {
            case 0:
                break;
            case 1:
                break;
            case 2:
                StageSelectorPanel.Open(stage);
                break;
        }
    }
}
