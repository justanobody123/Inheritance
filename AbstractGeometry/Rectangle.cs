using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace AbstractGeometry
{
	class Rectangle:Shape
	{
		double width;
		double heigth;
		public double Width
		{
			get => width;
			set
			{
				value = value < MIN_SIZE ? MIN_SIZE : value > MAX_SIZE ? MAX_SIZE : value;
				width = value;
			}
		}
		public double Heigth
		{
			get => heigth;
			set
			{
				value = value < MIN_SIZE ? MIN_SIZE : value > MAX_SIZE ? MAX_SIZE : value;
				heigth = value;
			}
		}
		public Rectangle(double width, double height, int startX, int startY, int lineWidth, Color color)
			:base(startX, startY, lineWidth, color)
		{
			Width = width;
			Heigth = heigth;
		}
		public override double GetArea()
		{
			return Width * Heigth;
		}
		public override double GetPerimeter()
		{
			return (Width + Heigth) * 2;
		}
		public override void Draw(PaintEventArgs e)
		{
			e.Graphics.DrawRectangle(new Pen(Color, LineWidth), StartX, StartY, (float)Width, (float)Heigth);
		}
		public override string ToString()
		{
			string result = "";
				//= base.ToString();
			result += $"Width:\t{Width}";
			result += $"Height:\t{Heigth}";
			result += base.ToString();
			return result;
		}

	}
}
