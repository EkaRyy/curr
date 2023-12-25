using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schedule
{
    public class Room: Axis
    {
        public int Id { get; set; }
        public String RoomN { get; set; }
        public int Count { get; set; }

        public List<Time> hardlimits { get; set; }
        public List<Time> softlimits { get; set; }

        public Room()
        {
            hardlimits = new List<Time>();
            softlimits = new List<Time>();
        }

        public string Name()
        {
            return RoomN;
        }

        public string getLimits()
        {
            StringBuilder sb = new StringBuilder();            
            foreach(var pair in hardlimits) 
                sb.Append(pair.getText()+"  ") ;
            return sb.ToString();
        }

        public bool isPairSoftDeny(Time pair)
        {
            return softlimits.Exists((p) => p.isPairEqual(pair));
        }

        public bool isPairHardDeny(Time pair)
        {
            return hardlimits.Exists((p) => p.isPairEqual(pair));
        }

        public override string ToString()
        {
            return Name();
        }

        public bool isMatchElem(Elem elem)
        {
            return elem.room.Id == Id;
        }
    }
}
