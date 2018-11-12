using SharpDX;
using SharpDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dune.Components
{
	class Sprite : Component
	{
		private Transform2D transform;
		public Vector2 Size { get; set; } = new Vector2(100);
		public Texture Texture { get; set; }
		public RectangleF TextureRect { get; set; } = new RectangleF(0.0f, 0.0f, 1.0f, 1.0f);


		protected override void Initialize(Entity entity)
		{
			transform = entity.Get<Transform2D>();
		}

		public void Render(Renderer renderer)
		{
			if (Texture != null)
			{
				renderer.Device.SetTexture(0, Texture);

				renderer.Device.DrawUserPrimitives(PrimitiveType.TriangleFan, 2, new Texture2DVertex[]
				{
					new Texture2DVertex{ position = new Vector4(transform.Position, 0.0f, 1.0f), texel = TextureRect.TopLeft },
					new Texture2DVertex{position=new Vector4(transform.Position.X + Size.X, transform.Position.Y, 0.0f, 1.0f), texel =TextureRect.TopRight },
					new Texture2DVertex{position =new Vector4(transform.Position+Size, 0.0f, 1.0f), texel =TextureRect.BottomRight },
					new Texture2DVertex{position=new Vector4(transform.Position.X, transform.Position.Y+Size.Y, 0.0f,1.0f), texel = TextureRect.BottomLeft }
				});
			}
		}
	}

	class SpriteSystem : ComponentSystem<Sprite>
	{
		public override void Render(Renderer renderer)
		{
			renderer.Device.VertexFormat = Texture2DVertex.Format;

			foreach (var c in Components)
			{
				c.Render(renderer);
			}
		}
	}
}
