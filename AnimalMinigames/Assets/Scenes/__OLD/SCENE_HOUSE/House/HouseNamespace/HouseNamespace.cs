using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace House
{
    public class Wow
    {
        public static void wow()
        {
            Debug.Log("awesome");
            PlayerHelp.Help();
        }
    }
    public class PlayerHelp : MonoBehaviour
    {
        public static void Help()
        {
            Debug.Log("플레이어 도와줘");
        }
    }

    public class BossHelp : MonoBehaviour
    {
        public static void Help()
        {
            Debug.Log("보스 도와줘");
        }
    }
}

