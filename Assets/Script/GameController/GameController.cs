using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class GameController : MonoBehaviour
{
    public delegate void WebRequestCallBack(long errorCode);

    [Header("network")]
    [Tooltip("网络接入点")]
    public string entrypoint;
    [Tooltip("房间字典")]
    public Dictionary<string, RoomDto> rooms;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        SceneManager.LoadScene("start");
    }

    // Update is called once per frame
    void Update()
    {

    }
    public IEnumerator GetRoom(WebRequestCallBack callback)
    {
        UnityWebRequest webRequest = UnityWebRequest.Get($"http://{entrypoint}/room");
        yield return webRequest.SendWebRequest();

        if (webRequest.isHttpError || webRequest.isNetworkError)
        {
            Debug.Log(webRequest.error);
        }
        else
        {
            Debug.Log(webRequest.downloadHandler.text);
            rooms = JsonUtility.FromJson<Serialization<string, RoomDto>>(webRequest.downloadHandler.text).ToDictionary();
        }
        callback(webRequest.responseCode);
    }
}
