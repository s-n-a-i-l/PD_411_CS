//#define SQUARE_FIRST
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Geometry
{
#if SQUARE_FIRST
	class Square : Shape
	{
		double side;
		public double Side
		{
			get => side;
			set => side = value < MIN_SIZE ? MIN_SIZE : value > MAX_SIZE ? MAX_SIZE : value;
		}
		public Square(double side, int start_x, int start_y, int line_width, Color color)
			: base(start_x, start_y, line_width, color)
		{
			Side = side;
		}
		public override double GetArea()
		{
			return Side * Side;
		}
		public override double GetPerimeter()
		{
			return Side * 4;
		}
		public override void Draw(PaintEventArgs e)
		{
			Pen pen = new Pen(Color.Red, LineWidth);//2 - толщина линии
			e.Graphics.DrawRectangle(pen, StartX, StartY, (float)Side, (float)Side);
			//400, 100 - начальные координаты (коорлинаты левого верзнего угла)

		}

		public override void Info(PaintEventArgs e)
		{
			Console.WriteLine($"Длина стороны: {Side}");
			base.Info(e);
		}
	} 
#endif

	class Square : Rectangle
	{
		public Square(double side, int start_x, int start_y, int line_width, Color color)
			: base(side, side, start_x, start_y, line_width, color) { }
	}

}
