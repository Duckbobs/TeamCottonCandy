using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net.Sockets;
using System;
using System.IO;
using System.Text;
using System.Threading;

public class Network : MonoBehaviour
{
    public string IP;
    NetworkEvent objNetworkEvent;

    Socket socket;
    static StreamWriter writer;
    static StreamReader reader;
    Queue<string> SendQue = new Queue<string>();
    Queue<string[]> RecvQue = new Queue<string[]>();
    public static string ID = "";

    string message = "";
    public bool serverConnected = false;

    // Start is called before the first frame update
    void Start()
    {
        objNetworkEvent = GetComponent<NetworkEvent>();
        connectServer();
    }
    // Update is called once per frame
    void Update()
    {
        while (SendQue.Count > 0)
        {
            string _Message = SendQue.Dequeue();
            try
            {
                writer.WriteLine(_Message);
                writer.Flush();
            }
            catch (Exception ea)
            {
                Debug.LogError("데이터 전송 실패 : " + _Message);
            }
        }
        while (RecvQue.Count > 0)
        {
            objNetworkEvent.UserEvent0(RecvQue.Dequeue());
        }
    }

    void connectServer()
    {
        try
        {
            Debug.Log("서버 연결 시도");
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Connect(IP, 20921);

            NetworkStream ns = new NetworkStream(socket);
            writer = new StreamWriter(ns, Encoding.UTF8);
            reader = new StreamReader(ns, Encoding.UTF8);

            Thread th = new Thread(receiveData);
            th.Start();

            serverConnected = true;
            Debug.Log("서버에 연결되었습니다.");
        }
        catch (Exception ea)
        {
            //Error
            Debug.LogError("서버 연결에 실패함."); ;
            Debug.LogError(ea.Message);
        }
    }
    void receiveData()
    {
        Debug.Log("수신 작업을 시작합니다.");
        try
        {
            while (true)
            {

                string readedData = reader.ReadLine();
                //Debug.Log("[서버로부터 수신함] " + readedData);

                string[] str = readedData.Split(' ');
                //foreach (string s in str)
                //{
                //    Debug.Log(s);
                //}

                RecvQue.Enqueue(str);
                //objNetworkEvent.UserEvent0(str);
            }
        }
        catch (Exception ea)
        {
            Debug.LogError("서버와의 수신이 중지 되었습니다.");
        }
    }

    public void writeMessage(object _Msg)
    {
        message += " " + Convert.ToString(_Msg);
    }
    public void sendMessage(string _To, string _Space, string _Case)
    {
        SendQue.Enqueue(_To + "\n" + _Space + "\n" + _Case + message);
        //Debug.Log(message);
        message = "";
    }
}
