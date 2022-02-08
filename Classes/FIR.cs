using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using System.Drawing.Drawing2D;

namespace VatTools
{
    public class FIR
    {
        public string firName { get; set; }
        public Point[] firPoints { get; set; }
        public FIR(string fn, Point[] points)
        {
            firName = fn;
            firPoints = points;
        }
    }
}
