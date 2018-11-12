using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dune
{
	class GameStack
	{
		Renderer renderer;
		private readonly ResourceManager resourceManager;
		private readonly SystemManager systemManager;
		private readonly Scene scene;
		private readonly Screen screen;
		Stack<GameStackItem> stack = new Stack<GameStackItem>();
		private bool enabled;
		Queue<GameStackItem> pushing = new Queue<GameStackItem>();
		int poping = 0;


		public GameStack(Renderer renderer, ResourceManager resourceManager, SystemManager systemManager, Scene scene, Screen screen)
		{
			this.renderer = renderer;
			this.resourceManager = resourceManager;
			this.systemManager = systemManager;
			this.scene = scene;
			this.screen = screen;
			enabled = true;
			Task.Run(new Action(Update));
		}

		private void Update()
		{
			int oldTime = Environment.TickCount;
			while (enabled)
			{
				int newTime = Environment.TickCount;
				float time = (newTime - oldTime) * 0.001f;
				oldTime = newTime;

				UpdateStack(time);

				Thread.Sleep(10);
			}
		}

		private void UpdateStack(float time)
		{
			while (poping != 0)
			{
				if (stack.Count != 0)
				{
					stack.Pop().Release();
					if (stack.Count != 0)
						stack.Peek().Resume();
				}
				poping--;
			}

			while (pushing.Count != 0)
			{
				if (stack.Count != 0)
				{
					stack.Peek().Suspend();
				}

				stack.Push(pushing.Dequeue());
				stack.Peek().Initial();
			}

			if (stack.Count != 0)
			{
				stack.Peek().Update(time);
			}
		}

		public T MakeItem<T>() where T : GameStackItem, new()
		{
			T t = new T
			{
				Renderer = renderer,
				ResourceManager = resourceManager,
				SystemManager = systemManager,
				Scene = scene,
				Screen = screen,
				GameStack = this
			};

			return t;
		}

		public void Push(GameStackItem item)
		{
			pushing.Enqueue(item);
		}

		public void Pop()
		{
			poping++;
		}

		public void KeyDown(Keys key)
		{
			if(stack.Count != 0)
			{
				stack.Peek().KeyDown(key);
			}
		}
	}

	class GameStackItem
	{
		public Renderer Renderer { get; set; }
		public ResourceManager ResourceManager { get; set; }
		public SystemManager SystemManager { get; set; }
		public Scene Scene { get; set; }
		public Screen Screen { get; set; }
		public GameStack GameStack { get; set; }


		public virtual void Initial() { }
		public virtual void Release() { }
		public virtual void Suspend() { }
		public virtual void Resume() { }
		public virtual void Update(float time) { }

		public virtual void KeyDown(Keys key) { }
	}
}
