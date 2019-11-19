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
    void Start()
    {
        
    }

    // ターゲットの追従
    private void Follow()
    {
        transform.position = _target.transform.position + new Vector3(0, 4, -_distance);
        transform.rotation = Quaternion.Euler(new Vector3(_rotate, 0, 0));
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
