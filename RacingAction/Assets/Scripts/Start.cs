using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Start : MonoBehaviour
{
    [SerializeField]
    private TextSetter _setter;
    // Start is called before the first frame update
    void Starts()
    {
        
    }
    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            _setter.SetText("Start");
            Debug.Log("スタート");
            // text.enabled = true;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
