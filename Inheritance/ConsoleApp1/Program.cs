using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Xml.Linq;



namespace ConsoleApp1
{
	internal class Program
	{
		static void Main(string[] args)
		{
			//IntPtr hwnd = GetConsoleWindow();
			//Graphics graphics = Graphics.FromHwnd(hwnd);
			//Rectangle window_rect = new Rectangle(Console.WindowLeft, Console.WindowTop, Console.WindowWidth, Console.WindowHeight);
			//PaintEventArgs e = new PaintEventArgs(graphics,window_rect);

			//e.Graphics.DrawRectangle(new Pen(Color.Red, 3), 300, 300, 100, 100);
			//Shape shape = new Shape(); невозможно создать экземпляр абстрактного класса

			Shape[] shapes =
			{
			  new Square(10, Color.Red),
			  new Circle(10, Color.Blue),
			  new Triangle(11, 12, Color.Green),
			  new Rectangle(10, 10, Color.Azure)
			};

			Random random = new Random();
			int index = random.Next(shapes.Length);

			shapes[index].Info();
			//Triangle triangle = new Triangle(11, 12, Color.Green);
			//triangle.Info();




		}
		//[DllImport("Kernel32.dll")]
		//public static extern IntPtr GetConsoleWindow();
		//[DllImport("Kernel32.dll")]
		//public static extern IntPtr GetDC(IntPtr hwnd);

	}
}
