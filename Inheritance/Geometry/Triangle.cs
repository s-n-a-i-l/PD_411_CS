using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using System.Drawing;

namespace Geometry
{
	abstract class Triangle:Shape
	{
		public abstract double GetHeight();
		public Triangle(int start_x, int start_y, int line_width, System.Drawing.Color color)
			: base(start_x, start_y, line_width, color) { }
		public override void Info(PaintEventArgs e)
		{
			Console.WriteLine($"Высота треугольника: {GetHeight()}");
			base.Info(e);
		}
	}
}
