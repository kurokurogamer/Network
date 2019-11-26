﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugGizmos : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDrawGizmos()
    {
        Matrix4x4 matrix = transform.localToWorldMatrix;
        Gizmos.matrix = matrix;
        Gizmos.DrawCube(Vector3.zero, Vector3.one);
    }
}
