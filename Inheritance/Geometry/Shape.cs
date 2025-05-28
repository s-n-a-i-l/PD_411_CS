using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Geometry
{
	abstract class Shape
	{
		static readonly int MIN_START_X = 100;
		static readonly int MAX_START_X = 1000;
		static readonly int MIN_START_Y = 50;
		static readonly int MAX_START_Y = 800;

		static readonly int MIN_LINE_WIDTH = 0;
		static readonly int MAX_LINE_WIDTH = 10;

		protected static readonly int MIN_SIZE = 50;
		protected static readonly int MAX_SIZE = 850;

		int start_x;
		int start_y;
		int line_width;
		public int StartX
		{
			get => start_x;
			set => start_x = (value < MIN_START_X ? MIN_START_X : value > MAX_START_X ? MAX_START_X : value);
			//		condition
		}
		public int StartY
		{
			get => start_y;
			set => start_y = value < MIN_START_Y ? MIN_START_Y : value > MAX_START_Y ? MAX_START_Y : value;
		}
		public int LineWidth
		{
			get => line_width;
			set => line_width = value < MIN_LINE_WIDTH ? MIN_LINE_WIDTH : value > MAX_LINE_WIDTH ? MAX_LINE_WIDTH : value;
		}
		public Color Color { get; set; }
		public Shape(int start_x, int start_y, int line_width, Color color)
		{
			this.StartX = start_x;
			this.StartY = start_y;
			this.LineWidth = line_width;
			Color = color;
		}
		public abstract double GetArea();
		public abstract double GetPerimeter();
		public abstract void Draw(PaintEventArgs e);
		public virtual void Info(PaintEventArgs e)
		{
			Console.WriteLine($"Площадь фигуры: {GetArea()}");
			Console.WriteLine($"Периметр фигуры:{GetPerimeter()}");
			Draw(e);
		}
	}
}
