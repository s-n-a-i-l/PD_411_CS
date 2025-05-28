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

	internal class Square:Shape
	{
		IntPtr hwnd = GetConsoleWindow();

		double side;
		public double Side {  get { return side; } set { side = value; } }

		public Square(double side,Color color) : base(color) 
		{
		  Side = side;
		}

		public override double GetArea()
		{
			return Side * Side;
		}

		public override double GetPerimeter()
		{
			return 4 * Side;
		}

		public override void Draw()
		{
			//for (int i = 0; i < Side; i++)
			//{
			//	for (int j = 0; j < Side; j++) 
			//	{
			//		Console.Write("* ");
			//	}
			//	Console.WriteLine();
			//}
			
			Graphics graphics = Graphics.FromHwnd(hwnd);
			System.Drawing.Rectangle window_rect = new System.Drawing.Rectangle(Console.WindowLeft, Console.WindowTop, Console.WindowWidth, Console.WindowHeight);
			PaintEventArgs e = new PaintEventArgs(graphics, window_rect);
			e.Graphics.DrawRectangle(new Pen(Color.Red, 3), 50, 200, 100, 100);

		}
		public override void Info()
		{
			Console.WriteLine($"Длина стороны:{Side}");
			base.Info();
		}
		[DllImport("Kernel32.dll")]
		public static extern IntPtr GetConsoleWindow();
		[DllImport("Kernel32.dll")]
		public static extern IntPtr GetDC(IntPtr hwnd);
	}
}
