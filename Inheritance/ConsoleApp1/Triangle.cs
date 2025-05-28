using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace ConsoleApp1
{
	internal class Triangle : Shape
	{
		IntPtr hwnd = GetConsoleWindow();

		double side;
		double hight;
		public double Hight { get { return hight; } set { hight = value; } }
		public double Side { get { return side; } set { side = value; } }

		public Triangle(double side, double hight, Color color) : base(color)
		{
			Hight = hight;
			Side = side;
		}

		public override double GetArea()
		{
			return (Side * Hight) / 2;
		}

		public override double GetPerimeter()
		{
			return Side * 3;
		}

		public override void Draw()
		{
			Graphics graphics = Graphics.FromHwnd(hwnd);
			System.Drawing.Rectangle window_rect = new System.Drawing.Rectangle(Console.WindowLeft, Console.WindowTop, Console.WindowWidth, Console.WindowHeight);
			PaintEventArgs e = new PaintEventArgs(graphics, window_rect);

			// Координаты трёх вершин треугольника
			Point[] trianglePoints = {
			 new Point(60, 240),   // Первая вершина
             new Point(160, 240),  // Вторая вершина
             new Point(110, 160)   // Третья вершина (верхушка)
             };

			// Рисуем треугольник
			e.Graphics.DrawPolygon(new Pen(Color.Green, 3), trianglePoints);
		}
		public override void Info()
		{
			Console.WriteLine($"Сторона:{Side} Высота:{Hight}");
			base.Info();
		}

		[DllImport("Kernel32.dll")]
		public static extern IntPtr GetConsoleWindow();
		[DllImport("Kernel32.dll")]
		public static extern IntPtr GetDC(IntPtr hwnd);
	}
}

