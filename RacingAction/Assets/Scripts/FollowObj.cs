using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObj : MonoBehaviour
{
    [SerializeField]
    protected GameObject _target;

    public void Follow()
    {
        if(_target == null)
        {
            return;
        }
        transform.position = _target.transform.position;
    }
}
