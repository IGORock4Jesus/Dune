using Dune.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dune
{
	class SystemManager : IDisposable
	{
		List<ComponentSystemBase> componentSystems;
		private bool enabled;
		private Task task;

		public SystemManager(Control control, Renderer renderer)
		{
			componentSystems = new List<ComponentSystemBase>
			{
				new Transform2DSystem(),
				new SpriteSystem(),
				new AnimSpriteSystem(),
				new TextSystem(renderer),
				new ButtonSystem()
			};

			renderer.Rendering += Rendering;
			control.MouseClick += Control_MouseClick;

			enabled = true;
			task = Task.Run(new Action(Update));
		}

		private void Control_MouseClick(object sender, MouseEventArgs e)
		{
			foreach (var s in componentSystems)
			{
				s.MouseClick(e.X, e.Y);
			}
		}

		public void Dispose()
		{
			enabled = false;
			task.Wait();
		}

		public void Update()
		{
			int oldTime = Environment.TickCount;
			while (enabled)
			{
				int newTime = Environment.TickCount;
				float time = (newTime - oldTime) * 0.001f;
				oldTime = newTime;

				foreach (var system in componentSystems)
				{
					system.Update(time);
				}
			}
		}

		internal ComponentSystem<T> Get<T>() where T : Component, new()
		{
			foreach (var system in componentSystems)
			{
				if (system is ComponentSystem<T>)
					return system as ComponentSystem<T>;
			}
			throw new SystemNotFoundException(typeof(T));
		}

		void Rendering(Renderer renderer)
		{
			foreach (var system in componentSystems)
			{
				system.Render(renderer);
			}
		}
	}
}
