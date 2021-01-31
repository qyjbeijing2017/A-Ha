using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour
{
    GameController controller;
    Vector3 oriMousePos;
    Vector3 oriPos;
    public bool pick;

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
    private void OnMouseDown()
    {
        oriMousePos = Input.mousePosition;
        oriPos = transform.position;
        pick = true;
        transform.SetSiblingIndex(transform.parent.childCount - 1);
        var renderer = GetComponent<SpriteRenderer>();
        renderer.sortingOrder = 1;
        transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
        transform.SetSiblingIndex(transform.parent.childCount - 1);
        GetComponent<Card>().drawCard.Play();
    }

    private void OnMouseDrag()
    {
        var offset = (Camera.main.ScreenToWorldPoint(Input.mousePosition).x - Camera.main.ScreenToWorldPoint(oriMousePos).x);
        var offsetY = (Camera.main.ScreenToWorldPoint(Input.mousePosition).y - Camera.main.ScreenToWorldPoint(oriMousePos).y);
        transform.position = new Vector3(oriPos.x + offset, oriPos.y + offsetY, transform.position.z);
    }

    private void OnMouseUp()
    {
        pick = false;

        var renderer = GetComponent<SpriteRenderer>();
        var card = GetComponent<Card>();
        renderer.sortingOrder = 0;
        transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

        var cards = FindObjectsOfType<Card>();
        for (int i = 0; i < cards.Length; ++i)
        {
            cards[i].transform.position = new Vector3(
                cards[i].transform.position.x,
                cards[i].transform.position.y,
                cards[i].transform.position.z + 0.01f
                );
        }

        card.transform.position = new Vector3(
                card.transform.position.x,
                card.transform.position.y,
               -1.0f
                );

        StartCoroutine(controller.Update((errorCode) => { }));
        GetComponent<Card>().dealCard.Play();
    }
}
