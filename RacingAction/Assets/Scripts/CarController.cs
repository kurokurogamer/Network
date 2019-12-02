using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    CharacterController controller;
    //Animator animator;

    [SerializeField]
    private float speed = 0.5f;
    [SerializeField]
    private float _rotaSpeed = 20;
    private float _angle;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        _angle = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //前進する
        if(Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += transform.forward * speed;
        }

        //バックする
        if(Input.GetKey(KeyCode.DownArrow))
        {
            transform.position -= transform.forward *speed;
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
}
