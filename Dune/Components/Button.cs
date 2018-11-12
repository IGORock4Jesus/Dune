using SharpDX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dune
{
	class Button 
	{
		enum State
		{
			Normal, Over, Pushed
		}

		Transform2D transform;
		Sprite sprite;
		State state;
		bool isMouseOver;

		private State SpriteState
		{
			get => state; set { state = value;
				switch (state)
				{
					case State.Normal:
						sprite.TextureRect = new RectangleF(0.0f, 0.0f, 1.0f, 0.33333f);
						break;
					case State.Over:
						sprite.TextureRect = new RectangleF(0.0f, 0.33333f, 1.0f, 0.66666f);
						break;
					case State.Pushed:
						sprite.TextureRect = new RectangleF(0.0f, 0.66666f, 1.0f, 1.0f);
						break;
					default:
						break;
				}
			}
		}

		public event ComponentHandler Click;

		internal void OnClick(Point point)
		{
			if (CheckHit(point))
			{
				SpriteState = State.Pushed;
				Click?.Invoke(this);
			}
		}

		private bool CheckHit(Point point)
		{
			return point.X >= transform.Position.X && point.X < transform.Position.X + sprite.Size.X &&
							point.Y >= transform.Position.Y && point.Y < transform.Position.Y + sprite.Size.Y;
		}

		protected override void Initialize(Entity entity)
		{
			transform = entity.Get<Transform2D>();
			sprite = entity.Get<Sprite>();
			SpriteState = State.Normal;
		}

		internal void OnMouseMove(Point point)
		{
			var isOver = CheckHit(point);
			if(isOver != isMouseOver)
			{
				if (isMouseOver = isOver)
				{
					SpriteState = State.Over;
				}
				else
				{
					SpriteState = State.Normal;
				}
			}
		}
	}

	class ButtonSystem : ComponentSystem<Button>
	{
		public override void MouseClick(int x, int y)
		{
			foreach (var item in Components)
			{
				item.OnClick(new Point(x, y));
			}
		}

		public override void MouseMove(int x, int y)
		{
			foreach (var item in Components)
			{
				item.OnMouseMove(new Point(x, y));
			}
		}
	}
}
