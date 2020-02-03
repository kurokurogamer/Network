using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System;
using System.Threading;


public class UDPServer : MonoBehaviour
{
    private string ipAddres = "172.20.39.22";
    private int _port = 2000;
    private UdpClient udp;
    private Thread thread;

    // Start is called before the first frame update
    void Start()
    {
        udp = new UdpClient(ipAddres, _port);
        udp.Client.ReceiveTimeout = 1000;
        thread = new Thread(new ThreadStart(ThreadMethod));
        thread.Start();
    }

    private void OnApplicationQuit()
    {
        udp.Close();
        thread.Abort();
    }

    private void ThreadMethod()
    {
        while (true)
        {
            IPEndPoint remoteEP = null;
            byte[] data = udp.Receive(ref remoteEP);
            string text = Encoding.ASCII.GetString(data);
            Debug.Log(text);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
