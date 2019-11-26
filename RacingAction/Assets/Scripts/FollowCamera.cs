using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField, Tooltip("追従するターゲット")]
    private GameObject _target = null;
    [SerializeField, Tooltip("カメラの追従距離")]
    private float _distance = 10;
    [SerializeField, Tooltip("カメラの角度")]
    private float _rotate = 0;
    private CarRotate _carRot = null;
    void Start()
    {
        _carRot = _target.GetComponent<CarRotate>();
    }

    // ターゲットの追従
    private void Follow()
    {
        if (_carRot == null)
        {
            return;
        }
        transform.position = -_target.transform.forward * _distance;
        transform.position = new Vector3(transform.position.x, 4, transform.position.z);
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.RotateAround(_target.transform.position, Vector3.up, _carRot.Angle);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // カメラ処理は移動が完了した後に行いたいのでLateUpdate内で書く
    private void LateUpdate()
    {
        Follow();
    }
}
