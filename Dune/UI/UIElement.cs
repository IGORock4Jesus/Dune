using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpDX.Direct3D9;

namespace Dune
{
	class UIElement
	{
		internal void Draw(Device device)
		{
			OnDraw(device);
		}

		protected virtual void OnDraw(Device device)
		{
			if (Visible && Children != null)
			{
				foreach (var ui in Children)
				{
					ui.Draw(device);
				}
			}
		}
		protected virtual void OnMouseDown() { }
		protected virtual void OnMouseUp() { }
		protected virtual void OnMouseMove() { }
		protected virtual void OnMouseEnter() { }
		protected virtual void OnMouseLeave() { }
		protected virtual void OnKeyDown(System.Windows.Forms.Keys keys) { }
		protected virtual void OnKeyUp(System.Windows.Forms.Keys keys) { }
		protected virtual void OnKeyPress(System.Windows.Forms.Keys keys) { }

		public List<UIElement> Children { get; set; } = new List<UIElement>();
		public bool Visible { get; set; }
	}
}
