using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class MainControl : MonoBehaviour
{
    // 接続するURL
    private const string DEFAULT_URL = "https://unity3d.com/jp/get-unity/download";
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(onSend(DEFAULT_URL));
    }

    IEnumerator onSend(string url)
    {
        UnityWebRequest webRequest = UnityWebRequest.Get(url);
        Debug.Log("検索中");
        yield return webRequest.SendWebRequest();
        //エラーが出ていないかチェック
        if (webRequest.isNetworkError)
        {
            //通信失敗
            Debug.Log(webRequest.error);
        }
        else
        {
            //通信成功
            Debug.Log(webRequest.downloadHandler.text);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
