using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dune
{
	class Entity
	{
		List<Component> components = new List<Component>();

		public string Name { get; set; }

		public void Add(Component component)
		{
			component.InitializeBase(this);
			components.Add(component);
		}

		internal void Kill()
		{
			foreach (var c in components)
			{
				c.Kill();
			}
		}

		public T Get<T>() where T : Component
		{
			foreach (var c in components)
			{
				if (c is T)
					return c as T;
			}
			throw new ComponentNotFoundException(typeof(T));
		}
	}
}
