using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugGizmos : MonoBehaviour
{
    // 描画タイプ
    enum MESH_TYPE
    {
        CUBE,
        SPHERE,
        MAX
    }

    MESH_TYPE _mode = MESH_TYPE.CUBE;
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
        switch (_mode)
        {
            case MESH_TYPE.CUBE:
                Gizmos.DrawCube(transform.position, Vector3.one);
                break;
            case MESH_TYPE.SPHERE:
                Gizmos.DrawSphere(transform.position, 0.5f);
                break;
            case MESH_TYPE.MAX:
            default:
                break;
        }
    }
}