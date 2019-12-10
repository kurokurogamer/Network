using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    private Rigidbody _rigid;
    // コントローラー
    private Controlle _controlle;

    [SerializeField, Tooltip("瞬間加速度")]
    private float _speed = 0.5f;
    [SerializeField, Tooltip("回転速度")]
    private float _rotaSpeed = 30;
    // ベクトル速度
    private Vector3 _vecSpeed;
    // 現在の回転角度
    private float _angle;
    // 衝突フラグ
    private bool colFlag;
    // Start is called before the first frame update
    void Start()
    {
        _rigid = GetComponent<Rigidbody>();
        _vecSpeed = Vector3.zero;
        _angle = 0;
        colFlag = false;
    }

    private void Accelerator()
    {
        if(_controlle.AccelerateObject())
        {
            _vecSpeed += transform.forward * _speed;
        }
    }

    private void Brake()
    {
        if(_controlle.DecelerateObject())
        {
            _vecSpeed -= transform.forward * _speed;
        }
    }

    private void Curve()
    {
        
    }

    private void Boost()
    {
    }

    private void SetPosition()
    {
        _rigid.velocity = _vecSpeed;
    }

    // Update is called once per frame
    void Update()
    {        // アクセル
        Accelerator();
        // ブレーキ
        Brake();
        //前進する
        if(Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += transform.forward * _speed;
        }
        //バックする
        if(Input.GetKey(KeyCode.DownArrow))
        {
            transform.position -= transform.forward * _speed;
        }

        //右回転
        if(Input.GetKey(KeyCode.RightArrow))
        {
            _angle += Time.deltaTime * _rotaSpeed;
           // transform.rotation += 
        }


        //左回転
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            _angle -= Time.deltaTime * _rotaSpeed;
        }
        transform.rotation = Quaternion.Euler(new Vector3(transform.eulerAngles.x, _angle, transform.eulerAngles.z));
    }

    private void OnCollisionStay(Collision collision)
    {

    }
}