using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace AbstractGeometry
{
	class Rectangle:Shape, IHaveDiagonal
	{
		double width;
		double height;
		public double Width
		{
			get => width;
			set
			{
				value = value < MIN_SIZE ? MIN_SIZE : value > MAX_SIZE ? MAX_SIZE : value;
				width = value;
			}
		}
		public double Height
		{
			get => height;
			set
			{
				value = value < MIN_SIZE ? MIN_SIZE : value > MAX_SIZE ? MAX_SIZE : value;
				height = value;
			}
		}
		public Rectangle(double width, double height, int startX, int startY, int lineWidth, Color color)
			:base(startX, startY, lineWidth, color)
		{
			Width = width;
			Height = height;
		}
		public double GetDiagonal()
		{
			return Math.Sqrt (Width * Width + Height * Height);
		}
		public override double GetArea()
		{
			return Width * Height;
		}
		public override double GetPerimeter()
		{
			return (Width + Height) * 2;
		}
		public override void Draw(PaintEventArgs e)
		{
			e.Graphics.DrawRectangle(new Pen(Color, LineWidth), StartX, StartY, (float)Width, (float)Height);
		}
		public override string ToString()
		{
			string result = "";
			result += $"Width: {Width}\n";
			result += $"Height: {Height}\n";
			result += $"Diagonal: {GetDiagonal()}\n";
			result += base.ToString();
			return result;
		}

	}
}
