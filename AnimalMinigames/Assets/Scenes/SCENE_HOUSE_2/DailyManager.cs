using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DailyManager : MonoBehaviour
{
    public GameObject[] rewardedBtns;
    public GameObject rewardBtn;
    public void RefreshUI()
    {
        rewardBtn.SetActive(false);
        for (int i = 0; i < rewardedBtns.Length; i++)
        {
            if (Global.Get("DailyCount") <= i)
            {
                rewardedBtns[i].SetActive(false);
                if (Global.Get("DailyCount") == i)
                {
                    if (Global.Get("DailyLastDay") != Global.Get("DailyToday"))
                    {
                        rewardBtn.SetActive(true);
                        rewardBtn.transform.position = rewardedBtns[i].transform.position;
                    }
                }
            }
            else
            {
                rewardedBtns[i].SetActive(true);
            }
        }
    }
    public void GetReward()
    {
        if (Global.Get("DailyLastDay") != Global.Get("DailyToday"))
        {
            int count = (int)Global.Get("DailyCount");
            Global.Set("DailyLastDay", Global.Get("DailyToday"));
            Global.Add("DailyCount", 1);

            if(Global.Get("DailyCount") >= 7)
                Global.Set("DailyCount", 0);
            RefreshUI();
        }
    }
}
