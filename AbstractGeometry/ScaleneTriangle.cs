using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractGeometry
{
	internal class ScaleneTriangle:Triangle
	{
		double leftSide;
		public double LeftSide
		{
			get => leftSide;
			set => leftSide = value < MIN_SIZE ? MIN_SIZE : value > MAX_SIZE ? MAX_SIZE : value;
		}
        public ScaleneTriangle(double triangleBase, double leftSide, double height, int startX, int startY, int lineWidth, Color color)
			:base(triangleBase, height, startX, startY, lineWidth, color)
        {
            LeftSide = leftSide;
			if (LeftSide < Height)
			{
                Console.WriteLine($"Эта сторона не может быть меньше высоты, проведенной к основанию. leftSide исправлено на {Height}");
				LeftSide = Height;
            }
        }
		public override double GetLeftSide()
		{
			return LeftSide;
		}
		public override double GetRightSide()
		{
			double theta = Math.Sqrt(LeftSide * LeftSide - Height * Height);
			return Math.Sqrt(Height * Height + (TriangleBase - theta) * (TriangleBase - theta));
		}
	}
}
