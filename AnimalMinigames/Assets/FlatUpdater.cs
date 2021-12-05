using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class FlatUpdater : MonoBehaviour
{
    public string stageName;
    public int num;
    public GameObject TutoObject;
    public GameObject EndTutoObject;
    public GameObject Unlocked_Object;
    public GameObject Locked_Object;
    public GameObject Wait_Object;
    public GameObject AllClear_Object;
    public GameObject NotRewarded_Object;

    public string valueName;
    public static int refreshAll = 0;

    public GameObject RewardObject;

    private void OnMouseUpAsButton()
    {
        if (Unlocked_Object.activeSelf == true)
        {
            // 퀘스트 아직 안 받았을 경우
            Global.Set(stageName + num.ToString(), "isWait", Global.TRUE);
            if(TutoObject != null)
                TutoObject.SetActive(true);
            Refresh();
        }
        else if(Wait_Object.activeSelf == true)
        {
            if (Global.Get(valueName) >= Global.Get(valueName, "Max"))
            {
                // 보상수령
                Global.Add(valueName, -Global.Get(valueName, "Max"));
                Global.Set(stageName + num.ToString(), "isRewarded", Global.TRUE);
                refreshAll = 10;
                if (EndTutoObject != null)
                    EndTutoObject.SetActive(true);

                // 코인 효과
                for (int i = 0; i < 10; i++)
                {
                    GameObject obj = Instantiate(RewardObject);
                    obj.transform.position = new Vector3(transform.position.x, transform.position.y, obj.transform.position.z);
                }
            }
        }
    }
    private void Start()
    {
        Refresh();
    }
    public void Refresh()
    {
        if (num > 1 && Global.Get(stageName + (num - 1).ToString(), "isRewarded") == Global.FALSE)
        {
            // 이전 퀘스트 미 클리어 상태일 경우
            Unlocked_Object.SetActive(false);
            Locked_Object.SetActive(true);
            Wait_Object.SetActive(false);
            AllClear_Object.SetActive(false);
            NotRewarded_Object.SetActive(false);
        }
        else if(Global.Get(stageName + num.ToString(), "isRewarded") == Global.FALSE)
        {
            // 보상 미수령 시
            if (Global.Get(stageName + num.ToString(), "isWait") == Global.TRUE)
            {
                // 퀘스트 받았을 경우
                Unlocked_Object.SetActive(false);
                Locked_Object.SetActive(false);
                Wait_Object.SetActive(true);
                AllClear_Object.SetActive(false);

                if (Global.Get(valueName) >= Global.Get(valueName, "Max"))
                {
                    NotRewarded_Object.SetActive(true);
                }
            }
            else
            {
                // 퀘스트 아직 안 받았을 경우
                Unlocked_Object.SetActive(true);
                Locked_Object.SetActive(false);
                Wait_Object.SetActive(false);
                AllClear_Object.SetActive(false);
                NotRewarded_Object.SetActive(false);
            }
        }
        else
        {
            // 완전히 끝났을 경우
            Unlocked_Object.SetActive(false);
            Locked_Object.SetActive(false);
            Wait_Object.SetActive(false);
            AllClear_Object.SetActive(true);
            NotRewarded_Object.SetActive(false);
        }
    }

    public void FixedUpdate()
    {
        if (!Application.isPlaying)
        {
            gameObject.name = stageName + num.ToString();
        }
        else
        {
            if (refreshAll > 0)
            {
                refreshAll -= 1;
                Refresh();
            }
        }
    }
}
