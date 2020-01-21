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
    public void Follow(float angle)
    {
        Vector3 distance = _target.transform.forward * -_distance;
        transform.position = new Vector3(_target.transform.position.x, 4, _target.transform.position.z) + distance;
        transform.rotation = Quaternion.Euler(_rotate, _target.transform.eulerAngles.y, _target.transform.eulerAngles.z);
        transform.RotateAround(_target.transform.position, Vector3.up, angle);
    }
}
