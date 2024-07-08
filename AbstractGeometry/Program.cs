using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;//Эта библиотека позволит подключать к нашему файлу другие DLL-файлы и использовать функции из этих DLL-файлов.

namespace AbstractGeometry
{
	internal class Program
	{
		static void Main(string[] args)
		{
			//Shape shape = new Shape();
			IntPtr hwnd = GetConsoleWindow();
			Graphics graphics = Graphics.FromHwnd(hwnd);
			System.Drawing.Rectangle rectangle = new System.Drawing.Rectangle(Console.WindowLeft, Console.WindowTop, Console.WindowWidth, Console.WindowHeight);
			Rectangle shapeRectangle = new Rectangle(100, 80, 200, 100, 5, Color.AliceBlue);
			PaintEventArgs e = new PaintEventArgs(graphics, rectangle);
			shapeRectangle.Info(e);
		}
		[DllImport("kernel32.dll")]
		public static extern bool GetStdHandle(int nStdHandle);
		[DllImport("kernel32.dll")]
		public static extern IntPtr GetConsoleWindow();
		[DllImport("kernel32.dll")]
		public static extern IntPtr GetDC(IntPtr hwnd);

	}
}
