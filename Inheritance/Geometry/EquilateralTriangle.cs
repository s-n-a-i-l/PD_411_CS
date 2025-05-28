using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Geometry
{
	class EquilateralTriangle:Triangle
	{
		double side;
		public double Side
		{
			get => side;
			set => side = value < MIN_SIZE ? MIN_SIZE : value > MAX_SIZE ? MAX_SIZE : value;
		}
		public EquilateralTriangle
			(
			double side,
			int start_x, int start_y, int line_width, System.Drawing.Color colo
			) : base(start_x, start_y, line_width, colo)
		{
			this.Side = side;
		}
		public override double GetHeight()
		{
			return Math.Sqrt(Math.Pow(Side, 2) - Math.Pow(Side / 2, 2));
		}
		public override double GetArea()
		{
			return Side * GetHeight() / 2;
		}
		public override double GetPerimeter()
		{
			return Side * 3;
		}

		public override void Draw(PaintEventArgs e)
		{
			Pen pen = new Pen(Color,LineWidth);
			Point[] vertex = new Point[] 
			{ new Point(StartX,StartY + (int)Side),
			  new Point(StartX+(int)Side, StartY+ (int)Side),
			  new Point(StartX +(int)Side/2, StartY+ (int)Side-(int)GetHeight()),
			};
			e.Graphics.DrawPolygon(pen, vertex);
		}
		public override void Info(PaintEventArgs e)
		{
			Console.WriteLine();
			Console.WriteLine(GetType());
			Console.WriteLine($"Длина стороны: {Side}");
			base.Info(e);
		}
	}
}
