using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Drawing;

namespace Geometry
{
	abstract class Triangle:Shape
	{
		public abstract double GetHeight();
		public Triangle(int start_x, int start_y, int line_width, System.Drawing.Color color)
			: base(start_x, start_y, line_width, color) { }
	}
}
