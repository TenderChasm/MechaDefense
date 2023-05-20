using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace MechaDefense
{
    interface IMeasurable
    {
        Point Coords { get; set; }
        Point Size { set; }

        bool IfPointInBorders(Point point);
    }
}
