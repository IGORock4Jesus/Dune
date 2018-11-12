using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dune
{
	class Screen
	{
		public Screen(int width, int height)
		{
			Width = width;
			Height = height;
		}

		public int Width { get; }
		public int Height { get; }
	}
}
