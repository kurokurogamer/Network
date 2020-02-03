using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarCollider : MonoBehaviour
{
    enum ColliderKind
    {
        Car,
        Shot,
        Wall,
        Obstruct,
    };
    // とりあえずenumでif文を埋めている
    //サーバが立ち上がって情報のやり取りができるようになったら
    //そこから情報をもらって判断
    ColliderKind colliderKind;
    CarController carController;
    // 車の反動の値(素)
    public float differenceElem;
    // 車の反動の値
    float difference;
    // Start is called before the first frame update
    void Start()
    {
        colliderKind = ColliderKind.Car;
    }

    // Update is called once per frame
    void Update()
    {
        // サーバから情報が返ってきて車との当たり判定でtrueだったら
        if (colliderKind == ColliderKind.Car)
        {
            Debug.Log("collideCar");
            CollideCar();
            //サーバから情報をもらって渡す
        }
        // サーバから情報が返ってきて弾との当たり判定でtrueだったら
        if (colliderKind == ColliderKind.Shot)
        {
            Debug.Log("collideShot");
            CollideShot();
        }
        // サーバから情報が返ってきて壁との当たり判定でtrueだったら
        if (colliderKind == ColliderKind.Wall)
        {
            Debug.Log("collideWall");
            CollideWall();
        }
        // サーバから情報が返ってきて障害物との当たり判定でtrueだったら
        if (colliderKind == ColliderKind.Obstruct)
        {
            Debug.Log("collideObstruct");
            CollideObstruct();
        }
    }
    // 相手の車と衝突した時の処理
    void CollideCar()//もらってきたコライダーを使ってコライダーの座標を作る
    {
        // Vector3 hitPos;
        //foreach (ContactPoint point in other.contacts)
        //{
        //    hitPos = point.point;
        //}

        //if (this.transform.position.x < hitPos.x)// 自機の右側に当たった
        //{
        //    difference = -differenceElem;
        //}
        //else if (this.transform.position.x > hitPos.x)// 自機の左側に当たった
        //{
        //    difference = differenceElem;
        //}
        difference = 20;
        LeaveCar(difference);
    }
    // 相手の弾に当たった時の処理
    void CollideShot()
    {
        //carController.SetCrashFlag(true);
    }
    // フィールドの壁に当たった時の処理
    void CollideWall()
    {

    }
    // フィールドの障害物に当たった時の処理
    void CollideObstruct()
    {
    }
    // 相手の車に当たって反動で離れる時の処理
    void LeaveCar(float difference)
    {
        Vector3 wVector = this.transform.position;
        wVector.x = wVector.x + difference;
    }
}
