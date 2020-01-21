using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public GameObject bullet;
    //スピード
    float speed;


    void Start()
    {
        speed = 5;
    }

    public void Shot(GameObject car)
    { 
        //runcherbulletにbulletのインスタンスを格納
        GameObject runcherBullet = GameObject.Instantiate(bullet);

        //アタッチしているオブジェクトの前方にbullet speedの速さで発射
        runcherBullet.GetComponent<Rigidbody>().velocity = transform.forward * speed;

        runcherBullet.transform.position = car.transform.position;
    }
}
