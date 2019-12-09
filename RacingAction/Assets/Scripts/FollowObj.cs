using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObj : MonoBehaviour
{
    [SerializeField]
    protected GameObject _target;
    private float _angle;
    private FollowCamera _followCamera;
    public float Angle
    {
        get { return _angle; }
    }

    void Start()
    {
        _followCamera = Camera.main.GetComponent<FollowCamera>();
        _angle = 0;
    }
    // 追従処理
    public void Follow()
    {
        if(_target == null)
        {
            return;
        }
        transform.position = _target.transform.position;
    }

    // Start is called before the first frame update


    public void SetAngle()
    {
        transform.rotation = Quaternion.Euler(new Vector3(transform.eulerAngles.x, _target.transform.eulerAngles.y, transform.eulerAngles.z));
        _angle = _target.transform.eulerAngles.y - transform.eulerAngles.y;

    }

    void Update()
    {
        Follow();
        SetAngle();
    }

    private void LateUpdate()
    {
        _followCamera.Follow(_angle);
    }
}
