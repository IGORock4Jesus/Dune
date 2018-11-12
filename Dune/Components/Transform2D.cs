using SharpDX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dune.Components
{
	class Transform2D : Component
	{
		public Vector2 Position { get; set; } = new Vector2();
		public float Rotation { get; set; } = 0.0f;
		public Vector2 Scaling { get; set; } = new Vector2(1.0f);
	}

	class Transform2DSystem : ComponentSystem<Transform2D>
	{

	}
}
