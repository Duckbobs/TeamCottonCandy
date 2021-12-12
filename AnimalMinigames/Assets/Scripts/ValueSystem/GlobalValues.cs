using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GlobalValues
{
    public static void init()
    {
        Global.Set("Stage", 1);


        Global.Set("Banana_001", 0); // 바나나
        Global.Set("Banana_001", "Max", 20);

        Global.Set("Banana_002", 0); // 무지개 바나나
        Global.Set("Banana_002", "Max", 100);

        Global.Set("Banana_003", 0); // 바나나 잎
        Global.Set("Banana_003", "Max", 500);

        Global.Set("Banana_004", 0); // 바나바나 플라워
        Global.Set("Banana_004", "Max", 500);

        Global.Set("Banana_005", 0); // 아이스 나나
        Global.Set("Banana_005", "Max", 500);

        Global.Set("Potion_001", 0); // 팔팔물약
        Global.Set("Potion_001", "Max", 500);


        Global.Set("Key", 5);
        Global.Set("Gold", 0);
        Global.Set("Gem", 0);

        // 튜토
        Global.Set("FirstQuestTuto", 0);
        for (int i = 0; i < 5; i++)
        {
            Global.Set("1-" + i, "isRewarded", Global.FALSE);
            Global.Set("1-" + i, "isWait", Global.FALSE);
        }

        // 출석체크
        Global.Set("DailyLastDay", 0);
        Global.Set("DailyToday", System.DateTime.Now.DayOfYear);
        Debug.Log(System.DateTime.Now.DayOfYear);
        Global.Set("DailyCount", 0);
    }
}