using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;

[System.Serializable]
public class timeInfo
{
    string abb;
    string client_ip;
    string datetime;
    int doyOfWeek;
    int dayOfYear;
    bool dst;
    string dstFrom;
    int dst_offset;
    string dstUntil;
    int rawOffset;
    string timeZone;
    long unixTime;
    string utcDatetime;
    string utcOffset;
    int weekNumber;

    public string getDateTime()
    {
        return datetime;
    }

}

public class setLocalTime : MonoBehaviour
{
    public GameObject timeTextObject;
    string url = "https://worldtimeapi.org/api/timezone/Europe/Paris";
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("GetDataFromWeb", 2f, 30f);
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
                Debug.Log(":\nTesting: " + data.getDateTime());
            }
        }
    }
}
