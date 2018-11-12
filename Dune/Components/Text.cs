using SharpDX;
using SharpDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dune.Components
{
	class Text : Component
	{
		Transform2D transform;
		Font font;
		private int _fontSize = 22;
		private string _fontFamily = "Arial";
		private Renderer renderer;

		public string Label { get; set; }
		public int FontSize
		{
			get => _fontSize; set
			{
				_fontSize = value;
				CreateFont();
			}
		}
		public string FontFamily
		{
			get => _fontFamily; set
			{
				_fontFamily = value;
				CreateFont();
			}
		}

		public Color Color { get; set; } = Color.White;


		protected override void Initialize(Entity entity)
		{
			transform = entity.Get<Transform2D>();

			CreateFont();
		}

		private void CreateFont()
		{
			if (font != null)
			{
				font.Dispose();
			}

			font = new Font(renderer.Device, new FontDescription
			{
				CharacterSet = FontCharacterSet.Russian,
				FaceName = _fontFamily,
				Height = _fontSize,
				Italic = false,
				MipLevels = 0,
				OutputPrecision = FontPrecision.TrueType,
				PitchAndFamily = FontPitchAndFamily.Roman,
				Quality = FontQuality.ClearType,
				Weight = FontWeight.Normal,
				Width = _fontSize / 2
			});
		}

		internal void Render(Renderer renderer)
		{
			font.DrawText(null, Label, (int)transform.Position.X, (int)transform.Position.Y, Color);
		}

		protected override void OnDestroy()
		{
			if (font != null)
			{
				font.Dispose();
			}
		}

		internal void SetRenderer(Renderer renderer)
		{
			this.renderer = renderer;
		}
	}

	class TextSystem : ComponentSystem<Text>
	{
		private Renderer renderer;

		public TextSystem(Renderer renderer)
		{
			this.renderer = renderer;
		}


		public override Text Create(Entity entity)
		{
			var c = base.Create(entity);

			c.SetRenderer(renderer);

			return c;
		}
	}
}
