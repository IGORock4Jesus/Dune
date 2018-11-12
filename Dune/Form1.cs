using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dune
{
	public partial class Form1 : Form
	{
		Renderer renderer;
		ResourceManager resourceManager;
		Scene scene;
		private SystemManager systemManager;
		Screen screen;
		GameStack gameStack;

		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			renderer = new Renderer(this);
			resourceManager = new ResourceManager(renderer.Device);
			scene = new Scene();
			systemManager = new SystemManager(renderer);
			screen = new Screen(ClientSize.Width, ClientSize.Height);

			gameStack = new GameStack(renderer, resourceManager, systemManager, scene, screen);

			gameStack.Push(gameStack.MakeItem<Game.LogoStackItem>());
		}

		private void Form1_FormClosed(object sender, FormClosedEventArgs e)
		{
			resourceManager.Dispose();
			renderer.Dispose();
		}

		private void Form1_KeyDown(object sender, KeyEventArgs e)
		{
			gameStack.KeyDown(e.KeyCode);
		}
	}
}
