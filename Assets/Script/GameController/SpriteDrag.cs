using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteDrag : MonoBehaviour
{
    //RaycastHit rayHit;
    RaycastHit2D rayHit2d;

    private GameObject BeganGameObject;
    private GameObject EndedGameObject;

    private Collider2D Begans;
    private Collider2D Endeds;
    void OnGUI()
    {
        Event Mouse = Event.current;

        if (Mouse.type == EventType.MouseDown)
        {
            Begans = Physics2D.OverlapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition), (1 << LayerMask.NameToLayer("Lu")));
            if (Begans)
            {
                BeganGameObject = Begans.gameObject;
            }
            //Debug.Log("MouseDown");
        }


        if (Mouse.type == EventType.MouseUp)
        {
            Endeds = Physics2D.OverlapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition), (1 << LayerMask.NameToLayer("Lu")));
            if (Endeds)
            {
                EndedGameObject = Endeds.gameObject;
            }
            if (BeganGameObject && EndedGameObject)
            {
                //h.gameObject.GetComponent<</span>SpriteRenderer>().sprite = a;
                EndedGameObject.GetComponent<SpriteRenderer>().sprite = BeganGameObject.GetComponent<SpriteRenderer>().sprite;
            }
            //Debug.Log("MouseUp");
        }
    }
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
