using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        }        
       
        //text.enabled = true;

   }
    // Update is called once per frame
    void Update()
    {
       
    }
}
