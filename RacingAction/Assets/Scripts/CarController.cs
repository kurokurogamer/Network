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
    // 加速度
    private float _nowVelocity = 0;
    private CarState state;
    [SerializeField, Tooltip("回転速度")]
    private float _rotaSpeed = 30;
    // 現在の回転角度
    private float _angle;
    // 衝突フラグ
    private bool colFlag;
    // Start is called before the first frame update
    void Start()
    {
        state = new CarState()
        {
            velocity = 0,
            point = new Vector3(0,0,0)
        };
        _rigid = GetComponent<Rigidbody>();
        _controlle = GetComponent<Controlle>();
        _nowVelocity = 0;
        _angle = 0;
        colFlag = false;
    }
    // 加速処理
    private void Accelerator()
    {
        
        if(_controlle.AccelerateObject())
        {
            _nowVelocity += _speed;
        }
        else
        {
            if (_nowVelocity > 0)
            {
                _nowVelocity -= _speed;
                if(_nowVelocity < 0)
                {
                    _nowVelocity = 0;
                }
            }
        }
    }
    // 減速処理
    private void Brake()
    {
        if(_controlle.DecelerateObject())
        {
            _nowVelocity -= _speed;
        }
        else
        {
            if (_nowVelocity < 0)
            {
                _nowVelocity += _speed;
                if (_nowVelocity > 0)
                {
                    _nowVelocity = 0;
                }
            }
        }
    }

    private void Curve()
    {
        if(_controlle.CurveObjectLeft())
        {
            _angle -= Time.deltaTime * _rotaSpeed;
        }
        else if(_controlle.CurveObjectRight())
        {
            _angle += Time.deltaTime * _rotaSpeed;
        }
    }

    private void Boost()
    {
    }

    private void SetVelocity()
    {
        _rigid.velocity = transform.forward * _nowVelocity;
    }

    private void SetRotation()
    {
        transform.rotation = Quaternion.Euler(new Vector3(transform.eulerAngles.x, _angle, transform.eulerAngles.z));
    }

    // Update is called once per frame
    void Update()
    {
        // アクセル
        Accelerator();
        // ブレーキ
        Brake();
        // カーブ
        Curve();
        // ブースト
        SetVelocity();
        // 回転反映
        SetRotation();

    }

    private void OnCollisionStay(Collision collision)
    {

    }
}