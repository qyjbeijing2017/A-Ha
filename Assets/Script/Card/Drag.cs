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
        StartCoroutine(controller.Update((errorCode) => { }));
    }
}
