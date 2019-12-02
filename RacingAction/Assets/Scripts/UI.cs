using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    public void Update()
    {
        AccelerateObject();
        DecelerateObject();
        SSAttackTarget();
        // FBAttackTarget()
        UseItem();
        CurveObjectRight();
        InputMouse();
    }
    // 加速ボタン
    public bool AccelerateObject()
    {
        if (Input.GetKey(KeyCode.X) || Input.GetKey("joystick button 1"))
        {
            Debug.Log("アクセル");
            return true;
        }
        else
        {
            return false;
        }
    }
    // 減速ボタン
    public bool DecelerateObject()
    {
        if (Input.GetKey(KeyCode.C) || Input.GetKey("joystick button 0"))
        {
            Debug.Log("ブレーキ");
            return true;
        }
        else
        {
            return false;
        }
    }
    // 攻撃ボタン(単発) 
    public bool SSAttackTarget()
    {
        if (Input.GetKeyDown(KeyCode.V) || Input.GetKey("joystick button 3"))
        {
            Debug.Log("単連射");
            return true;
        }
        return false;
    }
    // 攻撃ボタン(連射) 
    //public bool FBAttackTarget()
    //{
    //    if (Input.GetKey(KeyCode.V)|| Input.GetKey())
    //    {
    //Debug.Log("連射");
    //        return true;
    //    }
    //    return false;
    //}
    // アイテム発動ボタン
    public bool UseItem()
    {
        if (Input.GetKeyDown(KeyCode.B) || Input.GetKey("joystick button 2"))
        {
            Debug.Log("アイテム");
            return true;
        }
        return false;
    }
    // 右カーブボタン
    public bool CurveObjectRight()
    {
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetAxis("Horizontal2") >= 1)
        {
            Debug.Log("カーブ(右)");
            return true;
        }
        return false;
    }
    // 左カーブボタン
    public bool CurveObjectLeft()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetAxis("Horizontal2") <= -1)
        {
            Debug.Log("カーブ(左)");
            return true;
        }
        return false;
    }
    // マウス入力
    public Vector3 InputMouse()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 mousePosition = Input.mousePosition;
            Debug.Log("マウス情報" + mousePosition);
            return mousePosition;
        }
        return new Vector3(0, 0, 0);
    }
}
