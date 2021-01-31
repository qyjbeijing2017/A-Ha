using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartUIController : MonoBehaviour
{
    [Header("UI组件")]
    [Tooltip("网络入口输出框")]
    public UnityEngine.UI.InputField infEntryPoint;
    [Tooltip("用户名接口")]
    public UnityEngine.UI.InputField infUsername;
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
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnStartClick()
    {
        BtnStart.interactable = false;
        infEntryPoint.interactable = false;
        infUsername.interactable = false;
        controller.player = new PlayerDto();
        controller.player.id = System.Guid.NewGuid().ToString();
        controller.player.name = infUsername.text;
        controller.entrypoint = infEntryPoint.text;
        StartCoroutine(controller.SignIn((stateCode) =>
        {
            if (stateCode != 200)
            {
                BtnStart.interactable = true;
                infEntryPoint.interactable = true;
                infUsername.interactable = true;
                txtTip.text = msgNetworkError;
            }
            else
            {
                StartCoroutine(controller.Get((stateCodeGet) =>
                {
                    BtnStart.interactable = true;
                    infEntryPoint.interactable = true;
                    infUsername.interactable = true;
                    if (stateCode != 200)
                    {
                        txtTip.text = msgNetworkError;
                    }
                    else
                    {
                        for (var i = 0; i < controller.dto.players.Count; ++i)
                        {
                            if (controller.dto.players[i].id == controller.player.id)
                            {
                                controller.index = i;
                                break;
                            }
                        }
                        SceneManager.LoadScene("main");
                    }

                }));
            }
        }));
    }

    public void OnExistClick()
    {
        Application.Quit();
    }
}
