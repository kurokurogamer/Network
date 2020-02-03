using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class main : MonoBehaviour
{
    public GameObject car;　//動かすオブジェクトをUnity上でアタッチ

    string ipAddr = "172.20.39.22"; // ホスト側IPアドレス
    string ipAddr2 = "172.20.39.22"; //クライアント側IPアドレス

    UDPSystem udpSystem;
    char device = 'B'; // ホスト側動作はA,クライアント側動作はB

    private void Awake()
    {
        switch (device)
        {
            case 'A':
                udpSystem = new UDPSystem(null);
                udpSystem.Set(ipAddr, 5001, ipAddr2, 5002);
                break;
            case 'B':
                udpSystem = new UDPSystem((x) => Receive(x));
                udpSystem.Set(ipAddr2, 5002, ipAddr, 5001);
                udpSystem.Receive();
                break;
        }
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (device == 'A')
        {
            CarState sendData = car.GetComponent<CarController>().GetState();
            udpSystem.Send(sendData.ToByte(), 99);
        }
        if (device == 'B')
        {
        }
    }

    void Receive(byte[] bytes)
    {
        Debug.Log("Client");
    }
}