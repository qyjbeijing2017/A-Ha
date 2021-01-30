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
public class StateDto
{
    // 当前回合拥有者
    public int master;

    // 下个回合拥有者
    public int nextMaster;

    // 当前操作人
    public int operation;

    // 当前卡片
    public int currentCard;

    // 底色
    public int currentType;

    //commands
    public List<CommandDto> commands;

    //choose
    public List<int> cardChoose;

    // 卡片类型
    public List<int> cardTypes;

    // 卡片拥有者
    public List<int> cardOwner;
}
