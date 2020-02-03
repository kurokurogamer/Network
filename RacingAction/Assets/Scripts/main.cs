using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class main : MonoBehaviour
{
    public GameObject gameObject;　//動かすオブジェクトをUnity上でアタッチ
    public Text text; //座標表示用

    string ipAddr = "172.20.39.22"; // ホスト側IPアドレス
    string ipAddr2 = "172.20.39.32"; //クライアント側IPアドレス

    Vector3 vector3 = new Vector3(0, 0, 0);
    UDPSystem udpSystem;
    char device = 'A'; // ホスト側動作はA,クライアント側動作はB

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
            vector3 = gameObject.transform.position;
            CarState sendData = new CarState();
            udpSystem.Send(sendData.ToByte(), 99);
        }
        if (device == 'B')
        {
            gameObject.transform.position = vector3;
        }
        text.text = "(" + vector3.x + "," + vector3.y + "," + vector3.z + ")";
    }

    void Receive(byte[] bytes)
    {
        Debug.Log("Client");
    }
}