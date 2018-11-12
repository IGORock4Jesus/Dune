using System;
using System.Runtime.Serialization;

namespace Dune
{
	[Serializable]
	internal class ResourceNotFound : Exception
	{
		public ResourceNotFound(string name) 
			: base($"Ресурс {name} не найден")
		{
		}
	}
}