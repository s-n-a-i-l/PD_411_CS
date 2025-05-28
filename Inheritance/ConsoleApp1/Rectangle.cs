using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace ConsoleApp1
{
	internal class Rectangle:Shape
	{
		IntPtr hwnd = GetConsoleWindow();
		double side1;
		double side2;
		public double Side1 { get { return side1; } set { side1 = value; } }
		public double Side2 { get { return side2; } set { side2 = value; } }

		public Rectangle (double side1, double side2, Color color) : base (color)	
		{
			Side1 = side1;
			Side2 = side2;
		}

		public override double GetArea()
		{
			return Side1 * Side2;
		}

		public override double GetPerimeter()
		{
			return Side1 * 2 + Side2 * 2;
		}

		public override void Draw()
		{
			
			Graphics graphics = Graphics.FromHwnd(hwnd);
			System.Drawing.Rectangle window_rect = new System.Drawing.Rectangle(Console.WindowLeft, Console.WindowTop, Console.WindowWidth, Console.WindowHeight);
			PaintEventArgs u = new PaintEventArgs(graphics, window_rect);

			// Нарисовать прямоугольник
			u.Graphics.DrawRectangle(new Pen(Color.Orange, 3), 50, 200, 150, 80);
		}

		public override void Info()
		{
			Console.WriteLine($"Сторона1: {Side1} Сторона2: {Side2}");
			base.Info();
		}


		[DllImport("Kernel32.dll")]
		public static extern IntPtr GetConsoleWindow();
		[DllImport("Kernel32.dll")]
		public static extern IntPtr GetDC(IntPtr hwnd);
	}
}
