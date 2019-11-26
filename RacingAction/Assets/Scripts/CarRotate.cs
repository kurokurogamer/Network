using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarRotate : FollowObj
{
    private float _angle;
    public float Angle
    {
        get { return _angle; }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SetAngle(float angle)
    {
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            _angle += Time.deltaTime * 1;
        }
        if(Input.GetKey(KeyCode.RightArrow))
        {
            _angle -= Time.deltaTime * 1;
        }
        transform.rotation = Quaternion.Euler(new Vector3(transform.eulerAngles.x, _angle, transform.eulerAngles.z));
    }

    // Update is called once per frame
    void Update()
    {
        Follow();
        SetAngle(0);
    }
}
