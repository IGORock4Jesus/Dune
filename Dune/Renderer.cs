using SharpDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dune
{
	class Renderer : IDisposable
	{
		Device device;
		private bool enabled;
		private Task task;
		Direct3D direct;

		public Device Device => device;
		public delegate void RenderHandler(Renderer renderer);
		public event RenderHandler Rendering;

		public Renderer(Control  control)
		{
			direct = new Direct3D();
			device = new Device(direct, 0, DeviceType.Hardware, control.Handle, CreateFlags.HardwareVertexProcessing | CreateFlags.Multithreaded, new PresentParameters
			{
				AutoDepthStencilFormat = Format.D24S8,
				BackBufferCount = 1,
				BackBufferFormat = Format.X8R8G8B8,
				BackBufferHeight = control.ClientSize.Height,
				BackBufferWidth = control.ClientSize.Width,
				DeviceWindowHandle = control.Handle,
				EnableAutoDepthStencil = true,
				SwapEffect = SwapEffect.Discard,
				Windowed = true
			});

			device.SetRenderState(RenderState.Lighting, false);

			enabled = true;
			task = Task.Run(new Action(StartRender));
		}

		private void StartRender()
		{
			while (enabled)
			{
				device.Clear(ClearFlags.All, new SharpDX.Mathematics.Interop.RawColorBGRA(0, 0, 0, 255), 1.0f, 0);
				device.BeginScene();

				Rendering?.Invoke(this);

				device.EndScene();
				device.Present();
			}
		}

		public void Dispose()
		{
			enabled = false;
			task.Wait();
			device.Dispose();
			direct.Dispose();
		}
	}
}
