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
	abstract class Shape
	{
		public Color Color { get; set; }

		public Shape(Color color) 
		{
		 Color = color;
		}

		public abstract double GetArea();
		public abstract double GetPerimeter();
		public abstract void Draw();

		public virtual void Info()
		{
			Console.WriteLine($"Площадь фигуры: {GetArea()}");
			Console.WriteLine($"Периметр фигуры: {GetPerimeter()}");
			Draw();
		}
	}
}
