using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace VatTools
{
    public class FIR
    {
        public string firName { get; set; }
        public PointF[] firPoints { get; set; }
        public FIR(string fn, PointF[] points)
        {
            firName = fn;
            firPoints = points;
        }
    }
}
