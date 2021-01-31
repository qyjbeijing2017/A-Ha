using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Drag))]
[RequireComponent(typeof(SpriteRenderer))]
public class Card : MonoBehaviour
{
    public int id;
    Drag drag;
    private bool m_isBack = true;
    public bool isBack
    {
        get
        {
            return m_isBack;
        }
        set
        {
            if (value)
            {
                renderer.sprite = back;
            }
            else
            {
                renderer.sprite = font;
            }
            m_isBack = value;
        }
    }
    SpriteRenderer renderer;
    GameController controller;

    public Sprite font;
    public Sprite back;


    private bool m_isHide = false;

    public bool isHide
    {
        get
        {
            return m_isHide;
        }

        set
        {
            isBack = true;
            m_isHide = value;
        }
    }

    private void Awake()
    {
        drag = GetComponent<Drag>();
        renderer = GetComponent<SpriteRenderer>();
        controller = FindObjectOfType<GameController>();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == $"playerArea{controller.index}")
        {
            isHide = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == $"playerArea{controller.index}")
        {
            isHide = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && drag.pick)
        {
            isBack = !isBack;
        }
    }


}
