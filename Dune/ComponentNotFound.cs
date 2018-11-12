using System;
using System.Runtime.Serialization;

namespace Dune
{
	[Serializable]
	internal class ComponentNotFoundException : Exception
	{
		public ComponentNotFoundException(Type type)
			: base($"Компонент не найден: {type}")
		{
		}
	}
}