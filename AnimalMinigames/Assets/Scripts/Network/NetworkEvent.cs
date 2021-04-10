using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class NetworkEvent : MonoBehaviour
{
    int recentTime = 0;
    public Text objPing;
    public GameObject prefPlayer;

    uint offset = 1;
    public void UserEvent0(string[] s)
    {
        //Debug.Log("UserEvent0");
        offset = 1;
        switch (ReadLine(s))
        {
            case "Ping":
                objPing.text = ((Time.time - float.Parse(ReadLine(s)))*1000).ToString();
                break;
            case "Welcome!":
                Network.ID = ReadLine(s);
                break;
            case "Movement":
                string ID = ReadLine(s);
                float X = float.Parse(ReadLine(s));
                float Y = float.Parse(ReadLine(s));
                int Look = int.Parse(ReadLine(s));
                bool Move = bool.Parse(ReadLine(s));
                bool sendJump = bool.Parse(ReadLine(s));
                bool sendAttack = bool.Parse(ReadLine(s));
                break;
        }
    }
    string ReadLine(string[] s)
    {
        //Debug.Log(s[offset]);
        return s[offset++];
    }
    void Update()
    {
        if (recentTime != (int)(Time.time))
        {
            recentTime = (int)(Time.time);
            Network Comp = GetComponent<Network>();
            Comp.writeMessage(Time.time);
            Comp.sendMessage("Me", "0", "Ping");
        }
    }
}
