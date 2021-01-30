using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    [SerializeField]
    List<InfoGroup> players;

    [SerializeField]

    UnityEngine.UI.Text title;

    RoomDto m_dto;
    public RoomDto dto
    {
        set
        {
            m_dto = value;
            for (int i = 0; i < players.Count; i++)
            {
                if (i < m_dto.players.Count)
                {
                    players[i].text = m_dto.players[i].name;
                }
                else
                {
                    break;
                }
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnGo()
    {

    }
}
