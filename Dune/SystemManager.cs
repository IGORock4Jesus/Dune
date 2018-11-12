using Dune.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dune
{
	class SystemManager
	{
		List<ComponentSystemBase> componentSystems;


		public SystemManager(Renderer renderer)
		{
			componentSystems = new List<ComponentSystemBase>
			{
				new Transform2DSystem(),
				new SpriteSystem()
			};

			renderer.Rendering += Rendering;
		}

		public void Update(float time)
		{
			foreach (var system in componentSystems)
			{
				system.Update(time);
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
