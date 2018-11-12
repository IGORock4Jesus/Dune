using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dune
{
	class Component
	{
		public Entity Entity { get; private set; }

		protected virtual void Initialize(Entity entity) { }
		public void InitializeBase(Entity entity) { Entity = entity; Initialize(entity); }

		public delegate void ComponentHandler(Component component);
		public event ComponentHandler Destroyed;

		internal void Destroy()
		{
			OnDestroy();
			Destroyed?.Invoke(this);
		}

		protected virtual void OnDestroy()
		{
		}
	}
}
