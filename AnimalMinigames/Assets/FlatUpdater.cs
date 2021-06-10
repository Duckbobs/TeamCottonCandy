using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class FlatUpdater : MonoBehaviour
{
    public string globalName;
    public int num;
    public GameObject TutoObject;
    public GameObject Unlocked_Objects;
    public GameObject Locked_Objects;
    public GameObject Wait_Objects;
    public GameObject AllClear_Objects;

    public string valueName;
    public float valueMax;

    public Text textComp;
    public Slider sliderComp;

    private void OnMouseUpAsButton()
    {
        if (Unlocked_Objects.activeSelf == true)
        {
            // 퀘스트 아직 안 받았을 경우
            Global.Set(globalName + num.ToString(), "isWait", Global.TRUE);
            TutoObject.SetActive(true);
            Refresh();
        }
    }
    private void Start()
    {
        Refresh();
    }
    public void Refresh()
    {
        if (num > 1 && Global.Get(globalName + (num - 1).ToString(), "isRewarded") == Global.FALSE)
        {
            // 이전 퀘스트 미 클리어 상태일 경우
            Unlocked_Objects.SetActive(false);
            Locked_Objects.SetActive(true);
            Wait_Objects.SetActive(false);
            AllClear_Objects.SetActive(false);
        }
        else if(Global.Get(globalName + num.ToString(), "isRewarded") == Global.FALSE)
        {
            // 보상 미수령 시
            if (Global.Get(globalName + num.ToString(), "isWait") == Global.TRUE)
            {
                // 퀘스트 받았을 경우
                Unlocked_Objects.SetActive(false);
                Locked_Objects.SetActive(false);
                Wait_Objects.SetActive(true);
                AllClear_Objects.SetActive(false);

                sliderComp.value = Global.Get(valueName) / valueMax;
                textComp.text = (int)Global.Get(valueName) + "/" + (int)valueMax;
            }
            else
            {
                // 퀘스트 아직 안 받았을 경우
                Unlocked_Objects.SetActive(true);
                Locked_Objects.SetActive(false);
                Wait_Objects.SetActive(false);
                AllClear_Objects.SetActive(false);
            }
        }
        else
        {
            // 완전히 끝났을 경우
            Unlocked_Objects.SetActive(false);
            Locked_Objects.SetActive(false);
            Wait_Objects.SetActive(false);
            AllClear_Objects.SetActive(true);
        }
    }

    public void Update()
    {
        if (!Application.isPlaying)
        {
            gameObject.name = globalName + num.ToString();
        }
    }
}
