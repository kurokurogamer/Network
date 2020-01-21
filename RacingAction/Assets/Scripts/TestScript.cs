using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    public Attack attack;
    public GameObject car;
    //リキャストタイム(ショット)
    public int Recasttime;
    //加算タイマー
    int time;
    // Start is called before the first frame update
    void Start()
    {
        time = Recasttime * 60;
    }

    // Update is called once per frame
    void Update()
    {
        if (time++ >= Recasttime*60)
        {
            if (Input.GetKeyDown(KeyCode.V))
            { 
                attack.Shot(car);
                time = 0;
            }
        }
    }
}

