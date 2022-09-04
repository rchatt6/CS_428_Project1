using System.Collections;
using System.Collections.Generic;
using System;
using System.Globalization;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;

[System.Serializable]
public class timeInfo
{
    public string abbreviation;
    public string client_ip;
    public string datetime;
    public int day_of_week;
    public int day_of_year;
    public bool dst;
    public string dst_from;
    public int dst_offset;
    public string dst_until;
    public int raw_offset;
    public string timezone;
    public int unixtime;
    public string utc_datetime;
    public string utc_offset;
    public int week_number;

}

public class setLocalTime12hr : MonoBehaviour
{
    public GameObject timeTextObject;
    string url = "https://worldtimeapi.org/api/timezone/Europe/Paris";
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
                string timeSubstring = data.datetime.Substring(data.datetime.IndexOf("T") + 1, data.datetime.IndexOf(".")-11);
                DateTime dt = DateTime.Parse(timeSubstring);
                string time = dt.ToString("hh:mm tt");
                Debug.Log(":\n12HourTime: " + time);

                timeTextObject.GetComponent<TextMeshPro>().text = time;
            }
        }
    }
}
