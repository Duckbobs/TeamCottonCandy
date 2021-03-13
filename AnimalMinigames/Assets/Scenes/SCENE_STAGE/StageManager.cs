using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageManager : MonoBehaviour
{
    // stageIndex 값을 변경하면 보고있는 스테이지가 바뀝니다!
    public int stageIndex = 0;
    public Text txtMapName;

    // 스테이지 구조체
    [Serializable]
    public struct Stage
    {
        public string stageName;
        public AudioClip stageBgm;
        public GameObject stageObject;
        public bool isLock;
    };
    [SerializeField]
    public Stage[] Stages;

    private int before_stageIndex = -1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 스테이지에 변화가 생길경우
        if (stageIndex != before_stageIndex)
        {
            before_stageIndex = stageIndex;
            // 스테이지 명 설정
            txtMapName.text = Stages[stageIndex].stageName;
            for (int i = 0; i < Stages.Length; i++)
            {
                if (i != stageIndex)
                {
                    Stages[i].stageObject.SetActive(false);
                }
                else
                {
                    // 현재 스테이지 오브젝트로 활성화
                    Stages[i].stageObject.SetActive(true);
                }
            }
        }
    }
}
