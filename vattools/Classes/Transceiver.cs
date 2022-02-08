using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System.Data;
using System.Collections.Generic;

namespace VatTools
{
    public class Transceiver
    {
        public int id { get; set; }
        public int frequency { get; set; }
        public double latDeg { get; set; }
        public double lonDeg { get; set; }
        public double heightMslM { get; set; }
        public double heightAglM { get; set; }
    }
}    

