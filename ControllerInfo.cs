using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VatTools
{
    public class ControllerInfo
    {
        public string Name { get; set; }
        public string Callsign { get; set; }
        public ControllerInfo(string nm, string cs)
        {
            Name = nm;
            Callsign = cs;
        }
    }
}
