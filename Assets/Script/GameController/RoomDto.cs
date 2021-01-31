using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[Serializable]
public class RoomDto
{
    public List<PlayerDto> players;
    public long timeStemp;
    public StateDto state;
}
