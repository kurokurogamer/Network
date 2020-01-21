using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Goal : MonoBehaviour
{
    //public Text text;
    // Start is called before the first frame update
    void Start()
    {
       
    }
    void OnTriggerEnter(Collider collider)
    {

        if (collider.tag == "Player")
        {
            Debug.Log("ゴール");
        }
        if (collider.gameObject.name == "Car")
        {
            collider.ChengGoalStats(true);//からChengStatsを呼んで変更する
        }

        //text.enabled = true;

    }
    // Update is called once per frame
    void Update()
    {
    }
}
