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
    [SerializeField, Tooltip("最高速度")]
    private float _maxSpeed = 10.0f;
    // 加速度
    private float _nowVelocity = 0;
    private CarState state;
    [SerializeField, Tooltip("回転速度")]
    private float _rotaSpeed = 30;
    // 現在の回転角度
    private float _angle;
    //クラッシュフラグ
    bool CrashFlag;
    //クラッシュ回復までの時間
   private int RecoveryCrash = 2;
    // カウンター
    int count;
    // Start is called before the first frame update
    void Start()
    {
        state = new CarState()
        {
        };
        _rigid = GetComponent<Rigidbody>();
        _controlle = GetComponent<Controlle>();
        _nowVelocity = 0;
        _angle = 0;
        count = 0;
        CrashFlag = false;
    }
    // 加速処理
    private void Accelerator()
    {
        
        if(_controlle.AccelerateObject())
        {
            _nowVelocity += _speed;
            SetVelocity();
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
            SetVelocity();
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
        if(Mathf.Abs(_rigid.velocity.x) > _maxSpeed)
        {
            _rigid.velocity = new Vector3(_maxSpeed * (Mathf.Abs(_rigid.velocity.x) / _rigid.velocity.x), _rigid.velocity.y, _rigid.velocity.z);
        }
        if (Mathf.Abs(_rigid.velocity.z) > _maxSpeed)
        {
            _rigid.velocity = new Vector3(_rigid.velocity.x, _rigid.velocity.y, _maxSpeed * (Mathf.Abs(_rigid.velocity.z) / _rigid.velocity.z));
        }
    }

    private void SetRotation()
    {
        transform.rotation = Quaternion.Euler(new Vector3(transform.eulerAngles.x, _angle, transform.eulerAngles.z));
    }

    // Update is called once per frame
    void Update()
    {
        if (CrashFlag == true)
        {
            if (count++ > RecoveryCrash)
            {
                CrashFlag = false;
                count = 0;
            }
        }
        else
        {
            // アクセル
            Accelerator();
            // ブレーキ
            Brake();
            // カーブ
            Curve();
            // 回転反映
            SetRotation();
        }

    }
    public void  SetCrashFlag(bool flag)
    {
        CrashFlag = flag;
    }
}