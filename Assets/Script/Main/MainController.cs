using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainController : MonoBehaviour
{
    GameController controller;

    private void Awake()
    {
        controller = FindObjectOfType<GameController>();
    }
    // Start is called before the first frame update
    void Start()
    {
        controller.stopGet = false;
        controller.onEvent += controller.Prase;
        StartCoroutine(controller.GetLoop());

        var cads = FindObjectsOfType<Card>();

        for (var i = 0; i < cads.Length; ++i)
        {
            cads[i].id = i;
        }
        Shuffle();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnDestroy()
    {
        StartCoroutine(controller.SignOut((errorCode) => { }));
    }

    public void OnBack()
    {
        SceneManager.LoadScene("start");
    }

    public void Shuffle()
    {
        var cards = FindObjectsOfType<Card>();
        for (int i = 0; i < cards.Length; ++i)
        {
            var index = Random.Range(-1.0f, 0.0f);
            cards[i].transform.position = new Vector3(0, 0, index);
            cards[i].isBack = true;
        }

        StartCoroutine(controller.Update((ErrorCode) => { }));
    }
}
