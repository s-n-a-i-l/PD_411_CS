using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Policy;

namespace ConsoleApp1
{
	internal class Circle:Shape
	{
		IntPtr hwnd = GetConsoleWindow();

		double radius;
		 
		public double Radius { get { return radius; } set { radius = value; } }

		public Circle (double radius,Color color):base(color) 
		{
           Radius = radius;		
		}

		public override double GetArea()
		{
		  return Radius * 2 * Math.PI;
		}

		public override double GetPerimeter()
		{
			return (Radius * Math.PI) * (Radius * Math.PI);
		}

		public override void Draw()
		{
			Graphics graphics = Graphics.FromHwnd(hwnd);
			System.Drawing.Rectangle window_rect = new System.Drawing.Rectangle(Console.WindowLeft, Console.WindowTop, Console.WindowWidth, Console.WindowHeight);
			PaintEventArgs y = new PaintEventArgs(graphics, window_rect);
			y.Graphics.DrawEllipse(new Pen(Color.Blue, 3), 20, 200, 100, 100);

		}
		public override void Info()
		{
			Console.WriteLine($"Радиус:{Radius}");
			base.Info();
		}

		[DllImport("Kernel32.dll")]
		public static extern IntPtr GetConsoleWindow();
		[DllImport("Kernel32.dll")]
		public static extern IntPtr GetDC(IntPtr hwnd);
	}
}
