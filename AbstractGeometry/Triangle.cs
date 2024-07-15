using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AbstractGeometry
{
	abstract class Triangle:Shape, IAmTriangle
	{
		double triangleBase;
		public double TriangleBase
		{
			get=> triangleBase; 
			set=>triangleBase = value < MIN_SIZE ? MIN_SIZE : value > MAX_SIZE ? MAX_SIZE : value;
		}
		protected double height;
		public double Height
		{
			get => height;
			set => height = value < MIN_SIZE ? MIN_SIZE : value > MAX_SIZE ? MAX_SIZE : value;
		}
		public Triangle(double triangleBase, double height, int startX, int startY, int lineWidth, Color color)
			: base(startX, startY, lineWidth, color)
		{
			Height = height;
			TriangleBase = triangleBase;
		}
		public override double GetArea()
		{
			return triangleBase / 2 * height;
		}
		//Актуально для равностороннего и равнобедренного, требуется переопределение для разностороннего
		public virtual double GetLeftSide()
		{
			return Math.Sqrt(Math.Pow(TriangleBase / 2, 2) + Math.Pow(Height, 2));
		}
		//Актуально для равностороннего и равнобедренного, требуется переопределение для разностороннего
		public virtual double GetRightSide()
		{
			return GetLeftSide();
		}
		public override double GetPerimeter()
		{
			return TriangleBase + GetLeftSide() + GetRightSide();
		}
		public double GetLeftSin()
		{
			return Height / GetLeftSide();
		}
		public double GetRightSin() 
		{
			return Height / GetRightSide();
		}
		public double GetTopSin()
		{
			return Math.Sin(GetTopAngle());
		}
		public double GetLeftAngle()
		{
			return Math.Asin(GetLeftSin()) * 180 / Math.PI;
		}
		public double GetRightAngle()
		{
			return Math.Asin(GetRightSin()) * 180 / Math.PI;
		}
		public double GetTopAngle()
		{
			return 180 - GetRightAngle() - GetLeftAngle();
		}
		public double GetLeftCos()
		{
			double radians = GetLeftAngle() * (Math.PI / 180);
			return Math.Cos(radians);
		}
		public double GetRightCos()
		{
			double radians = GetRightAngle() * (Math.PI / 180);
			return Math.Cos(radians);
		}
		public double GetTopCos()
		{
			return Math.Cos(GetTopAngle());
		}
		public override void Draw(PaintEventArgs e)
		{
			Point[] points = new Point[]
			{
				new Point(StartX, StartY),
				new Point((int)(StartX - GetLeftSide() * GetLeftCos()), StartY + (int)height),
				new Point((int)(StartX + GetRightSide() * GetRightCos()), StartY + (int)height)
			};
			e.Graphics.DrawPolygon(new Pen(Color, LineWidth), points);

		}
		public override string ToString()
		{
			string result = "";
			result += $"Base: {TriangleBase}\n";
			result += $"Height: {Height}\n";
			result += base.ToString();
			return result;
		}
	}
}
