using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextSetter : MonoBehaviour
{
    Text text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SetText(string str, float delteTime = 1.0f)
    {
        text.text = str;
        gameObject.SetActive(true);
        Invoke("Active", delteTime);
    }

    public void Active()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
