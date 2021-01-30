using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
public enum CardType
{
    LOST,
    FOUND,
    COOPERATION,
    SUPER
}
public class Card : MonoBehaviour
{
    [Tooltip("卡片编号")]
    public string id;

    [Tooltip("卡片的颜色、类型")]
    public CardType type;

    public List<CommandDto> command;

    [HideInInspector]
    public bool isBack = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
