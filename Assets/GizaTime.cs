using System.Collections;
using System.Collections.Generic;
using System;
using System.Globalization;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;

public class GizaTime : MonoBehaviour
{
    public GameObject timeTextObject;
    string url = "https://worldtimeapi.org/api/timezone/Africa/Cairo";
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("GetDataFromWeb", 2f, 15f);
    }

    void GetDataFromWeb()
    {

        StartCoroutine(GetRequest(url));
    }

    IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {

            yield return webRequest.SendWebRequest();


            if (webRequest.result == UnityWebRequest.Result.ConnectionError)
            {
                Debug.Log(": Error: " + webRequest.error);
            }
            else
            {
                Debug.Log(":\nReceived: " + webRequest.downloadHandler.text);

                var json = webRequest.downloadHandler.text;
                timeInfo data = JsonUtility.FromJson<timeInfo>(json);
                string timeSubstring = data.datetime.Substring(data.datetime.IndexOf("T") + 1, data.datetime.IndexOf(".") - 11);
                DateTime dt = DateTime.Parse(timeSubstring);
                string time = dt.ToString("HH:mm");
                Debug.Log(":\n24HourTime: " + time);

                timeTextObject.GetComponent<TextMeshPro>().text = time;
            }
        }
    }
}
