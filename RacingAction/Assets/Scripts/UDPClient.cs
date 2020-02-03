using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

public class UDPClient : MonoBehaviour
{
    // ブロードキャストアドレス
    private string ipAddres = "172.20.39.22";
    private int _port = 2000;
    private UdpClient udp;

    // Start is called before the first frame update
    void Start()
    {
        udp = new UdpClient(ipAddres, _port);
        udp.Connect(ipAddres, _port);
    }

    public void CheckNetWork()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            SendData("");
        }
    }

    public void SendData(string json)
    {
        byte[] dgram = Encoding.UTF8.GetBytes(json);
        udp.Send(dgram, dgram.Length);
    }

    // Update is called once per frame
    void Update()
    {
        CheckNetWork();
    }

    private void OnApplicationQuit()
    {
        udp.Close();
    }
}
