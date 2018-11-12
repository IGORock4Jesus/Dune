using SharpDX;
using SharpDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Dune.Components
{
	struct Texture2DVertex
	{
		public Vector4 position;
		public Vector2 texel;

		public const VertexFormat Format = VertexFormat.PositionRhw | VertexFormat.Texture1;
		public static readonly int Size = Marshal.SizeOf(typeof(Texture2DVertex));
	}
}
