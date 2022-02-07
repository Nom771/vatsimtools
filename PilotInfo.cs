using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VatTools
{
    public class PilotInfo
    {
        public string Callsign { get; set; }
        public string Squawk { get; set; }
        public string AssignedSquawk { get; set; }
        public int Altitude { get; set; }
        public int GroundSpeed { get; set; }
        public string ACType { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public PilotInfo(string cs, string sq, string asq, int alt, int gspd, string ac, string org, string dst)
        {
            Callsign = cs;
            Squawk = sq;
            AssignedSquawk = asq;
            Altitude = alt;
            GroundSpeed = gspd;
            ACType = ac;
            Origin = org;
            Destination = dst;
        }
    }
}
