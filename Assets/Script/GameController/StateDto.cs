using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


[Serializable]
public class CommandDto
{
    public string id;
    public int value;
}

[Serializable]
public class CardDate
{
    public int id;
    public float x;
    public float y;
    public float z;
    public bool isBack;
}

[Serializable]
public class StateDto
{
    public List<CardDate> cardDates;
}
