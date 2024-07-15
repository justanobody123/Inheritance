using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractGeometry
{
	internal class EqulateralTriangle:Triangle
	{
        public EqulateralTriangle(double side, int startX, int startY, int lineWidth, Color color)
            : base(side, side * Math.Sqrt(3) / 2, startX, startY, lineWidth, color)
        {
            height = side * Math.Sqrt(3) / 2;
		}
    }
}
