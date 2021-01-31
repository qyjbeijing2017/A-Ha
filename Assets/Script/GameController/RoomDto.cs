using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[Serializable]
public class RoomDto
{
    public string name;
    public List<PlayerDto> _players;
    public string id;
    public long lastmodified;
}

