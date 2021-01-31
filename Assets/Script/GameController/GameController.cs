using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

[SerializeField]
public class CardsSet
{
    public int count;
}

public class GameController : MonoBehaviour
{
    public delegate void RequestCallBack(long stateCode);
    public delegate void Change(RoomDto roomDto);


    [Header("network")]
    [Tooltip("网络接入点")]
    public string entrypoint;

    [HideInInspector]
    public PlayerDto player;

    [HideInInspector]
    public int index;

    [HideInInspector]
    public RoomDto dto;

    public event Change onEvent;

    public event Change afterEvent;

    [HideInInspector]
    public bool stopGet = true;

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
    public IEnumerator SignIn(RequestCallBack callBack)
    {
        string json = JsonUtility.ToJson(player);
        byte[] postBytes = System.Text.Encoding.UTF8.GetBytes(json);
        UnityWebRequest webRequest = new UnityWebRequest($"http://{entrypoint}", "PUT");
        webRequest.uploadHandler = (UploadHandler)new UploadHandlerRaw(postBytes);
        webRequest.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        webRequest.SetRequestHeader("Content-Type", "application/json");

        yield return webRequest.SendWebRequest();

        if (webRequest.isHttpError || webRequest.isNetworkError)             //如果其 请求失败，或是 网络错误
        {
            Debug.LogError(webRequest.error); //打印错误原因
        }
        else //请求成功
        {
            player = JsonUtility.FromJson<PlayerDto>(webRequest.downloadHandler.text);
        }
        callBack(webRequest.responseCode);
    }

    public IEnumerator Update(RequestCallBack callBack)
    {

        var cards = FindObjectsOfType<Card>();

        List<CardDate> cardsDate = new List<CardDate>();

        for (int i = 0; i < cards.Length; ++i)
        {
            var card = new CardDate();
            card.x = cards[i].transform.position.x;
            card.y = cards[i].transform.position.y;
            card.z = cards[i].transform.position.z;
            card.isBack = cards[i].isBack;
            card.id = cards[i].id;
            cardsDate.Add(card);
        }
        dto.state.cardDates = cardsDate;

        string json = JsonUtility.ToJson(dto.state);
        byte[] postBytes = System.Text.Encoding.UTF8.GetBytes(json);
        UnityWebRequest webRequest = new UnityWebRequest($"http://{entrypoint}", "POST");
        webRequest.uploadHandler = (UploadHandler)new UploadHandlerRaw(postBytes);
        webRequest.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        webRequest.SetRequestHeader("Content-Type", "application/json");

        yield return webRequest.SendWebRequest();

        if (webRequest.isHttpError || webRequest.isNetworkError)             //如果其 请求失败，或是 网络错误
        {
            Debug.LogError(webRequest.error); //打印错误原因
        }
        callBack(webRequest.responseCode);
    }

    public IEnumerator SignOut(RequestCallBack callBack)
    {
        stopGet = true;
        string json = JsonUtility.ToJson(player);
        byte[] postBytes = System.Text.Encoding.UTF8.GetBytes(json);
        UnityWebRequest webRequest = new UnityWebRequest($"http://{entrypoint}", "DELETE");
        webRequest.uploadHandler = (UploadHandler)new UploadHandlerRaw(postBytes);
        webRequest.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        webRequest.SetRequestHeader("Content-Type", "application/json");

        yield return webRequest.SendWebRequest();

        if (webRequest.isHttpError || webRequest.isNetworkError)             //如果其 请求失败，或是 网络错误
        {
            Debug.LogError(webRequest.error); //打印错误原因
        }
        callBack(webRequest.responseCode);
    }

    public IEnumerator Get(RequestCallBack callBack)
    {
        UnityWebRequest webRequest = UnityWebRequest.Get($"http://{entrypoint}");
        yield return webRequest.SendWebRequest();
        if (webRequest.isHttpError || webRequest.isNetworkError)             //如果其 请求失败，或是 网络错误
        {
            Debug.LogError(webRequest.error); //打印错误原因
        }
        else //请求成功
        {
            var dtoOld = dto;
            dto = JsonUtility.FromJson<RoomDto>(webRequest.downloadHandler.text);
            if (dto.timeStemp > dtoOld.timeStemp)
            {
                onEvent?.Invoke(dto);
            }
        }
        callBack(webRequest.responseCode);
    }


    public IEnumerator GetLoop()
    {
        while (!stopGet)
        {
            yield return StartCoroutine(Get((errCode) => { }));
            yield return new WaitForSeconds(0.1f);
        }
    }


    public void Prase(RoomDto changeDto)
    {
        var cards = FindObjectsOfType<Card>();
        var cardsList = new List<Card>(cards);

        cardsList.Sort((a, b) => { return a.id - b.id; });

        changeDto.state.cardDates.Sort((a, b) => { return a.id - b.id; });

        List<CardDate> cardsDate = new List<CardDate>();

        for (int i = 0; i < cards.Length; ++i)
        {
            cardsList[i].transform.position = new Vector3(changeDto.state.cardDates[i].x, changeDto.state.cardDates[i].y, changeDto.state.cardDates[i].z);
            cardsList[i].isBack = changeDto.state.cardDates[i].isBack;
        }
    }


    public List<CardsSet> cardSet;

    public void GameStart(RoomDto changeDto)
    {
        int counts = 0;

        for (int i = 0; i < cardSet.Count; ++i)
        {
            counts += cardSet[i].count;
        }
    }
}
