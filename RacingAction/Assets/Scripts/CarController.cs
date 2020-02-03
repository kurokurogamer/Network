using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class CarController : MonoBehaviour
{
    // プレイヤーのステータス
    private CarState _state;

    private Rigidbody _rigid;
    // コントローラー
    private Controlle _controlle;
    private float _nowVelocity;
    [SerializeField, Tooltip("瞬間加速度")]
    private float _speed = 0.5f;
    [SerializeField, Tooltip("最高速度")]
    private float _maxSpeed = 10.0f;
    [SerializeField, Tooltip("回転速度")]
    private float _rotaSpeed = 30;

    // 現在の回転角度
    private float _angle;
    // 衝突フラグ
    private bool _colFlag;
    [SerializeField, Tooltip("プレイヤーID")]
    private int _id = 0;
    public int ID
    {
        get { return _id; }
    }

    [SerializeField]
    private JsonNetwork _network = null;
    // Start is called before the first frame update
    void Start()
    {
        _rigid = GetComponent<Rigidbody>();
        _controlle = GetComponent<Controlle>();
        _angle = 0;
        _colFlag = false;
        // プレイヤーのステータスを生成
        _state = new CarState();
        _state.velocity = 0;
        _state.pos = new float[3];
        _state.pos[0] = transform.position.x;
        _state.pos[1] = transform.position.y;
        _state.pos[2] = transform.position.z;
        _state.goalCar = false;
        Debug.Log(_state);
        // Networkの管理クラスに登録
        _network.AddPlayer(_state);
    }

    //public CarState NetWork()
    //{
    //    if(_network == null)
    //    {
    //        return _state;
    //    }
    //    return _state;
    //}

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
        // アクセル
        Accelerator();
        // ブレーキ
        Brake();
        // カーブ
        Curve();
        // 回転反映
        SetRotation();
    }

    private void OnCollisionStay(Collision collision)
    {

    }
}