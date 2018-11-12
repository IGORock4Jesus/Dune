using SharpDX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dune.Components
{
	class Button : Component
	{
		Transform2D transform;
		Sprite sprite;


		public event ComponentHandler Click;

		internal void OnClick(Point point)
		{
			if(point.X >= transform.Position.X && point.X < transform.Position.X + sprite.Size.X &&
				point.Y >= transform.Position.Y && point.Y < transform.Position.Y + sprite.Size.Y)
			{
				Click?.Invoke(this);
			}
		}

		protected override void Initialize(Entity entity)
		{
			transform = entity.Get<Transform2D>();
			sprite = entity.Get<Sprite>();
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
	}
}
