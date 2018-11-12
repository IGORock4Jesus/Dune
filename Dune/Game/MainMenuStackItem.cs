using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dune.Game
{
	class MainMenuStackItem : GameStackItem
	{

		public override void KeyDown(Keys key)
		{
			if(key == Keys.Escape)
			{
				GameStack.Pop();
			}
		}
	}
}
