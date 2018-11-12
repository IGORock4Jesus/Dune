using System;
using System.Runtime.Serialization;

namespace Dune
{
	[Serializable]
	internal class SystemNotFoundException : Exception
	{

		public SystemNotFoundException(Type type)
			: base($"Система не найдена: {type}")
		{
		}

	}
}