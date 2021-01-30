using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    }

    // Update is called once per frame
    void Update()
    {

    }
}
