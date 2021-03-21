using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageSelectorEvent : MonoBehaviour
{
    public GameObject StagePanel;

    private void Awake()
    {
        StagePanel.SetActive(false);
    }

    private void OnMouseUpAsButton()
    {
        StagePanel.SetActive(true);
    }
}
