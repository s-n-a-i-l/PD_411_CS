using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Geometry
{
	class Program
	{
		static void Main(string[] args)
		{
			if (2 == 3)Console.WriteLine("Ура!!!");

			IntPtr hwnd = GetConsoleWindow();
			Graphics graphics = Graphics.FromHwnd(hwnd);
			System.Drawing.Rectangle window_rect = new System.Drawing.Rectangle
				(
				Console.WindowLeft, Console.WindowTop,
				Console.WindowWidth, Console.WindowHeight
				);
			PaintEventArgs e = new PaintEventArgs(graphics, window_rect);
			//e.Graphics.DrawRectangle(new Pen(Color.Red, 2), 400, 100, 100, 100);

			//Shape shape = new Shape(); //Невозможно создать экземпляр абстрактного класса
			Square square = new Square(2000, 300, 0, 152, Color.Red);
			square.Info(e);

			Rectangle rectangle = new Rectangle(300, 200, 400, 50, 3, Color.AliceBlue);
			rectangle.Info(e);

			Circle circle = new Circle(75, 500, 50, 5, Color.Yellow);
			circle.Info(e);
		}
		[DllImport("kernel32.dll")]
		public static extern IntPtr GetConsoleWindow();
		[DllImport("kernel32.dll")]
		public static extern IntPtr GetDC(IntPtr hwnd);
	}
}
