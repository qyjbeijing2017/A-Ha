using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartUIController : MonoBehaviour
{
    [Header("UI组件")]
    [Tooltip("网络入口输出框")]
    public UnityEngine.UI.InputField InfEntryPoint;
    [Tooltip("开始按钮")]
    public UnityEngine.UI.Button BtnStart;
    [Tooltip("提示框")]
    public UnityEngine.UI.Text txtTip;

    [Space(20)]
    [Tooltip("网络错误提示信息")]
    public string msgNetworkError;


    GameController controller;

    private void Awake()
    {
        controller = FindObjectOfType<GameController>();
    }

    // Start is called before the first frame update
    void Start()
    {
        InfEntryPoint.text = controller.entrypoint;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnStartClick()
    {
        BtnStart.interactable = false;
        InfEntryPoint.interactable = false;
        StartCoroutine(controller.GetRoom((stateCode) =>
        {
            BtnStart.interactable = true;
            InfEntryPoint.interactable = true;
            if (stateCode != 200)
            {
                txtTip.text = msgNetworkError;
            }
            else
            {
                SceneManager.LoadScene("room");
            }
        }));
    }

    public void OnExistClick()
    {
        Application.Quit();
    }
}
