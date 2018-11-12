using Dune.Components;
using SharpDX;
using SharpDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Dune.Component;
using Button = Dune.Components.Button;

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
			ResourceManager.LoadTexture("button", "MainMenu\\button.png");

			CreateButton(NewGame, "newGameButton", new Point(100, 100), new Size2(300, 70), "НОВАЯ ИГРА");
			CreateButton(LoadGame, "loadGameButton", new Point(100, 300), new Size2(300, 70), "ЗАГРУЗИТЬ ИГРУ");
		}

		private void NewGame(Component component)
		{
			MessageBox.Show($"Entity = {component.Entity.Name}");
		}

		void LoadGame(Component component)
		{
			MessageBox.Show($"Entity = {component.Entity.Name}");
		}

		private void CreateButton(ComponentHandler onClick, string name, Point point, Size2 size, string text)
		{
			var entity = new Entity { Name = name };

			var transform = SystemManager.Get<Transform2D>().Create(entity);
			transform.Position = new Vector2(point.X, point.Y);

			var sprite = SystemManager.Get<Components.Sprite>().Create(entity);
			sprite.Size = new Vector2(size.Width, size.Height);
			sprite.Texture = ResourceManager.Get<Texture>("button");

			var textComponent = SystemManager.Get<Text>().Create(entity);
			textComponent.Label = text;
			textComponent.Color = Color.Black;

			var button = SystemManager.Get<Button>().Create(entity);
			button.Click += onClick;

			Scene.Add(entity);
		}
	}
}
