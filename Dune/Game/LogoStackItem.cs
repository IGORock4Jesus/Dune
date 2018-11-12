using Dune.Components;
using SharpDX;
using SharpDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Dune.Game
{
	class LogoStackItem : GameStackItem
	{

		public override void Initial()
		{
			// 1. загружаем ресурсы для лого
			// 2. Отображаем лого и загрузку
			// 3. загружаем ресурсы для меню

			ResourceManager.LoadTexture("logo", "Logo\\logo.jpg");
			ResourceManager.LoadTexture("loading", "Logo\\anim_test_alpha.png");

			Resume();
		}

		private void TransToMainMenu()
		{
			Thread.Sleep(3000);

			GameStack.Push(GameStack.MakeItem<MainMenuStackItem>());
		}

		public override void Resume()
		{
			Entity logo = new Entity();

			var transform = SystemManager.Get<Transform2D>().Create(logo);
			Vector2 size = new Vector2(Screen.Width - 200.0f, Screen.Height - 200.0f);

			transform.Position = new SharpDX.Vector2((Screen.Width - size.X) / 2.0f, (Screen.Height - size.Y) / 2.0f);

			var sprite = SystemManager.Get<Components.Sprite>().Create(logo);
			sprite.Size = size;
			sprite.Texture = ResourceManager.Get<Texture>("logo");

			Scene.Add(logo);

			Entity loading = new Entity();

			transform = SystemManager.Get<Transform2D>().Create(loading);
			size = new Vector2(256);
			transform.Position = new Vector2((Screen.Width - size.X) / 2.0f, Screen.Height - size.Y);

			var animSprite = SystemManager.Get<AnimSprite>().Create(loading);
			animSprite.SwapSpeed = 0.2f;
			animSprite.Texture = ResourceManager.Get<Texture>("loading");
			animSprite.Size = size;
			animSprite.FrameCount = 12;

			Scene.Add(loading);

			// через 3 секунды переходим на главное меню
			Task.Run(new Action(TransToMainMenu));
		}
		public override void Suspend()
		{
			Release();
		}

		public override void Release()
		{
			Scene.Clear();
		}
	}
}
