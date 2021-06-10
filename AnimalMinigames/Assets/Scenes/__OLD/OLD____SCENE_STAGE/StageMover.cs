using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageMover : MonoBehaviour
{
    public __OLD_StageManager stageManager;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }


    // 스테이지 좌우 이동
    public void goLeftStage()
    {
        stageManager.stageIndex -= 1;
        if (stageManager.stageIndex < 0)
            stageManager.stageIndex = stageManager.Stages.Length-1;
    }
    public void goRightStage()
    {
        stageManager.stageIndex += 1;
        if (stageManager.stageIndex >= stageManager.Stages.Length)
            stageManager.stageIndex = 0;
    }
}
