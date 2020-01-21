using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    [SerializeField]
    private TextSetter _setter;
    // Start is called before the first frame update
    void Start()
    {
       
    }
    void OnTriggerEnter(Collider collider)
    {

        if (collider.tag == "Player")
        {
            _setter.SetText("Goal");
            Debug.Log("ゴール");
            CarState car;
            car = collider.GetComponent<CarState>();
           if (car != null)
           {
               car.ChengGoalStats(true);//からChengStatsを呼んで変更する
           }
        }
        //text.enabled = true;

    }
    // Update is called once per frame
    void Update()
    {
    }
}
