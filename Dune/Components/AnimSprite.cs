using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpDX;
using SharpDX.Direct3D9;

namespace Dune.Components
{
	/// <summary>
	/// Анимированный спрайт.
	/// </summary>
	class AnimSprite : Component
	{
		/// <summary>
		/// Скорость переключения кадров.
		/// </summary>
		public float SwapSpeed { get; set; } = 1.0f;
		public Texture Texture { get; internal set; }
		public Vector2 Size { get; internal set; }
		//public Size2 FrameSize { get; set; }

		int counter; // текущий кадр
		float cursor; // текущее время спрайта
		private Transform2D transform;

		public int FrameCount { get; set; }

		protected override void Initialize(Entity entity)
		{
			transform = entity.Get<Transform2D>();
		}

		internal void Render(Renderer renderer)
		{
			if (Texture != null && FrameCount > 0)
			{
				renderer.Device.SetTexture(0, Texture);

				// вычисляем текущий кадр
				int currentFrame = (int)(cursor / SwapSpeed);
				float tileWidth = 1.0f / FrameCount;
				
				renderer.Device.DrawUserPrimitives(PrimitiveType.TriangleFan, 2, new Texture2DVertex[]
				{
					new Texture2DVertex{
						position = new Vector4(transform.Position, 0.0f, 1.0f),
						texel = new Vector2(tileWidth * currentFrame , 0.0f) },
					new Texture2DVertex{
						position =new Vector4(transform.Position.X + Size.X, transform.Position.Y, 0.0f, 1.0f),
						texel = new Vector2(tileWidth * (currentFrame+1), 0.0f) },
					new Texture2DVertex{
						position =new Vector4(transform.Position+Size, 0.0f, 1.0f),
						texel = new Vector2(tileWidth * (currentFrame+1), 1.0f) },
					new Texture2DVertex{
						position =new Vector4(transform.Position.X, transform.Position.Y+Size.Y, 0.0f,1.0f),
						texel = new Vector2(tileWidth * currentFrame , 1.0f) }
				});
			}
		}
		internal void Update(float time)
		{
			cursor += time;
			if (cursor >= FrameCount * SwapSpeed)
				cursor -= FrameCount * SwapSpeed;
		}
	}

	class AnimSpriteSystem : ComponentSystem<AnimSprite>
	{
		public override void Update(float time)
		{
			foreach (var item in Components)
			{
				item.Update(time);
			}
		}

		public override void Render(Renderer renderer)
		{
			renderer.Device.SetRenderState(RenderState.AlphaBlendEnable, true);
			renderer.Device.SetRenderState(RenderState.SourceBlend, Blend.SourceAlpha);
			renderer.Device.SetRenderState(RenderState.DestinationBlend, Blend.InverseSourceAlpha);

			foreach (var item in Components)
			{
				item.Render(renderer);
			}

			renderer.Device.SetRenderState(RenderState.AlphaBlendEnable, false);
		}
	}
}
