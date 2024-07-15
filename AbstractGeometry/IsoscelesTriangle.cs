using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractGeometry
{
	internal class IsoscelesTriangle:Triangle
	{
        public IsoscelesTriangle(double triangleBase, double height, int startX, int startY, int lineWidth, Color color)
            : base (triangleBase, height, startX, startY, lineWidth, color)
        {
            
        }

    }
}
