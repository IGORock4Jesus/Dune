using SharpDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dune
{
	class HUD
	{
		UIElement root;
		public UIElement Root { get => root; set => root = value; }

		public void Draw(Device device)
		{
			root?.Draw(device);
		}

		
	}
}
