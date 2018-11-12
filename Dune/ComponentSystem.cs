using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dune
{
	class ComponentSystemBase
	{
		public virtual void Update(float time) { }

		public virtual void Render(Renderer renderer) { }

		public virtual void MouseClick(int x, int y) { }
		public virtual void MouseMove(int x, int y) { }
	}

	class ComponentSystem<T> : ComponentSystemBase where T : Component, new()
	{
		List<T> components = new List<T>();
		protected List<T> Components => components.ToList();


		public void Add(T component)
		{
			components.Add(component);
		}

		public void Remove(T component)
		{
			components.Remove(component);
		}

		public virtual T Create(Entity entity)
		{
			T t = new T();
			t.Destroyed += Component_Killed;
			entity.Add(t);
			Add(t);
			return t;
		}

		private void Component_Killed(Component component)
		{
			Remove(component as T);
		}
	}

}
