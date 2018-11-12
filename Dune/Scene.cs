using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dune
{
	class Scene
	{
		List<Entity> entities = new List<Entity>();


		internal void Add(Entity entity)
		{
			entities.Add(entity);
		}

		internal void Clear()
		{
			foreach (var e in entities)
			{
				e.Kill();
			}
			entities.Clear();
		}
	}
}
