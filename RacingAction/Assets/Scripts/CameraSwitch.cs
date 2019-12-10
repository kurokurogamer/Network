using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    //[SerializeField]

    public Camera MainCamera;//車を後ろから撮影するカメラ
    public Camera FPCamera;//車の中から正面を撮影するカメラ
    public Camera BackCamera;//車を正面から撮影するカメラ

    enum CAMERA_MODE
    {
        FP,
        TP,
        BACK
    }

    
    enum GAME_MODE
    {

    }

   CAMERA_MODE mode;
   GAME_MODE GameMode;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))//TPS視点
        {
            MainCamera.enabled = true;//車を後ろから撮影するカメラ
            FPCamera.enabled = false;//車の中から正面を撮影するカメラ
            BackCamera.enabled = false;//車を正面から撮影するカメラ
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            BackCamera.enabled = true;//車を正面から撮影するカメラ
            FPCamera.enabled = false;//車の中から正面を撮影するカメラ
            MainCamera.enabled = false;//車を後ろから撮影するカメラ
        }

        if(Input.GetKeyDown(KeyCode.Q))//FPS視点
        {
            FPCamera.enabled = true;//車の中から正面を撮影するカメラ
            MainCamera.enabled = false;//車を後ろから撮影するカメラ
            BackCamera.enabled = false;//車を正面から撮影するカメラ
        }
    }
}
