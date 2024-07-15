using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;//Эта библиотека позволит подключать к нашему файлу другие DLL-файлы и использовать функции из этих DLL-файлов.

namespace AbstractGeometry
{
	internal class Program
	{
		static void Main(string[] args)
		{
			IntPtr hwnd = GetConsoleWindow();
			Graphics graphics = Graphics.FromHwnd(hwnd);
			System.Drawing.Rectangle windowRectangle = new System.Drawing.Rectangle(Console.WindowLeft, Console.WindowTop, Console.WindowWidth, Console.WindowHeight);
			PaintEventArgs e = new PaintEventArgs(graphics, windowRectangle);
			Rectangle rectangle = new Rectangle(100, 50, 450, 100, 10, Color.AliceBlue);
			rectangle.Draw(e);
			Square square = new Square(100, 500, 200, 10, Color.Aqua);
			square.Draw(e);
			Circle circle = new Circle(50, 550, 320, 5, Color.Red);
			circle.Draw(e);
			IsoscelesTriangle iTriangle = new IsoscelesTriangle(100, 50, 300, 300, 13, Color.Blue);
			iTriangle.Draw(e);
			EqulateralTriangle eTriangle = new EqulateralTriangle(80, 200, 400, 3, Color.BlueViolet);
			eTriangle.Draw(e);
			ScaleneTriangle sTriangle = new ScaleneTriangle(150, 80, 70, 120, 280, 5, Color.DarkGray);
			sTriangle.Draw(e);

		}
		[DllImport("kernel32.dll")]
		public static extern bool GetStdHandle(int nStdHandle);
		[DllImport("kernel32.dll")]
		public static extern IntPtr GetConsoleWindow();
		[DllImport("kernel32.dll")]
		public static extern IntPtr GetDC(IntPtr hwnd);

	}
}
