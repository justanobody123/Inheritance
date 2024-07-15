using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractGeometry
{
	internal class Square:Rectangle
	{
		public Square(double width, int startX, int startY, int lineWidth, Color color)
			: base(width, width, startX, startY, lineWidth, color)
		{ }

	}
}
