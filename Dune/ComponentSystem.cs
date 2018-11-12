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

		public T Create(Entity entity)
		{
			T t = new T();
			t.Killed += Component_Killed;
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
