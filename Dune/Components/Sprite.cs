using SharpDX;
using SharpDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dune.Components
{
	class Sprite : IDrawable
	{
		public Vector2 ScalingCenter { get; set; } = new Vector2(0.0f);
		public float ScalingRotation { get; set; }
		public Vector2 Scaling { get; set; } = new Vector2(1.0f);
		public Vector2 RotationCenter { get; set; } = new Vector2(0.0f);
		public float Rotation { get; set; }
		public Vector2 Translation { get; set; } = new Vector2(0.0f);
		public Vector2 Size { get; set; } = new Vector2(100);
		public Texture Texture { get; set; }
		public RectangleF TextureRect { get; set; } = new RectangleF(0.0f, 0.0f, 1.0f, 1.0f);


		public void Draw(Device device)
		{
			if (Texture != null)
			{
				device.SetTexture(0, Texture);

				Matrix matrix = Matrix.Transformation2D(ScalingCenter, ScalingRotation, Scaling, RotationCenter, Rotation, Translation);
				device.SetTransform(TransformState.World, matrix);

				device.DrawUserPrimitives(PrimitiveType.TriangleFan, 2, new Texture2DVertex[]
				{
					new Texture2DVertex{ position = new Vector4(0.0f, 0.0f, 0.0f, 1.0f), texel = TextureRect.TopLeft },
					new Texture2DVertex{position=new Vector4(Size.X, 0.0f, 0.0f, 1.0f), texel =TextureRect.TopRight },
					new Texture2DVertex{position =new Vector4(Size, 0.0f, 1.0f), texel =TextureRect.BottomRight },
					new Texture2DVertex{position=new Vector4(0.0f, Size.Y, 0.0f,1.0f), texel = TextureRect.BottomLeft }
				});
			}
		}
	}

}
