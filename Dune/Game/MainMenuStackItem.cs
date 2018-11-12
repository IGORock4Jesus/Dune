using Dune.Components;
using SharpDX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Dune.Component;

namespace Dune.Game
{
	class MainMenuStackItem : GameStackItem
	{

		public override void KeyDown(Keys key)
		{
			if(key == Keys.Escape)
			{
				GameStack.Pop();
			}
		}

		public override void Initial()
		{
			ResourceManager.LoadTexture("buttonDefault", "")

			CreateButton(NewGame, "newGameButton", new Point(100, 100), new Size2(300, 70), "НОВАЯ ИГРА");
		}

		private void NewGame(Component component)
		{
			throw new NotImplementedException();
		}

		private void CreateButton(ComponentHandler onClick, string name, Point point, Size2 size, string text)
		{
			var entity = new Entity { Name = name };

			var transform = SystemManager.Get<Transform2D>().Create(entity);
			transform.Position = new Vector2(point.X, point.Y);

			var sprite = SystemManager.Get<Sprite>().Create(entity);
			sprite.Size = new Vector2(size.Width, size.Height);
			sprite.Texture = 

		}
	}
}
