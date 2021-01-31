using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomController : MonoBehaviour
{
    [Tooltip("房间预制体")]
    public Room room;

    GameController controller;
    // Start is called before the first frame update
    void Start()
    {
        //controller = FindObjectOfType<GameController>();

        //var enumerator = controller.rooms.GetEnumerator();

        //while (enumerator.MoveNext())
        //{
        //    var newRoom = Instantiate(room);
        //    newRoom.dto = enumerator.Current.Value;
        //    newRoom.transform.parent = transform;
        //}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
