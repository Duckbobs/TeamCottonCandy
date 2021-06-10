using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GlobalValues
{
    public static void init()
    {
        Global.Set("Stage", 1);


        Global.Set("Banana_Basic", 0); // 바나나
        Global.Set("Banana_Rainbow", 0); // 무지개 바나나
        Global.Set("Potion_Strong", 0); // 팔팔물약
        Global.Set("Banana_Leaf", 0); // 바나나 잎
        Global.Set("Banana_Flower", 0); // 바나바나 플라워
        Global.Set("Banana_Ice", 0); // 아이스 나나



        Global.Set("Key", 5);
        Global.Set("Gold", 0);
        Global.Set("Gem", 0);

        Global.Set("FirstQuestTuto", 0);
        for (int i = 0; i < 5; i++)
        {
            Global.Set("1-" + i, "isRewarded", Global.FALSE);
            Global.Set("1-" + i, "isWait", Global.FALSE);
        }
    }
}