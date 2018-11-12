using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpDX.Direct3D9;

namespace Dune
{
	class ResourceManager : IDisposable
	{
		List<ResourceBase> resources = new List<ResourceBase>();
		private Device device;
		readonly string path = ConfigurationManager.AppSettings["DataPath"];

		public ResourceManager(Device device)
		{
			this.device = device;
		}

		public void LoadTexture(string name, string filename)
		{
			var tex = Texture.FromFile(device, Path.Combine(path, filename));
			if(tex != null)
			{
				Resource<Texture> texture = new Resource<Texture>()
				{
					Name = name,
					Data = tex
				};
				resources.Add(texture);
			}
		}
		public void Dispose()
		{
			foreach (var r in resources)
			{
				r.Dispose();
			}
		}

		internal T Get<T>(string name) where T : Resource
		{
			foreach (var r in resources)
			{
				if (r.Name == name)
					return (r as Resource<T>).Data;
			}
			throw new ResourceNotFound(name);
		}
	}

	abstract class ResourceBase : IDisposable
	{
		public string Name { get; set; }
		public abstract void Dispose();
	}
	class Resource<T> : ResourceBase where T : IDisposable
	{
		public T Data { get; set; }
		public override void Dispose()
		{
			if (Data != null)
				Data.Dispose();
		}
	}
}
